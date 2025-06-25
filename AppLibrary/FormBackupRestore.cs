using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AppLibrary.FormSupport;
using DevExpress.XtraSplashScreen;
using AppLibrary.ClassSupport;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Globalization;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraCharts.Native;

namespace AppLibrary
{
    public partial class FormBackupRestore : DevExpress.XtraEditors.XtraForm
    {
        public FormBackupRestore()
        {
            InitializeComponent();
        }

        private string _DATABASE_NAME;
        private bool _isNoTruncateOn = true;

        private void FormBackupRestore_Load(object sender, EventArgs e)
        {   // ____TABLE DATABASE____
            this.dATABASESTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dATABASESTableAdapter.Fill(qLTVDataSet.DATABASES);
            // Config GridView DSBACKUP
            gridViewDSBACKUP.OptionsView.ShowGroupPanel = false;
            gridViewDSBACKUP.OptionsFind.AlwaysVisible = true;
            gridViewDSBACKUP.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm...";
            // Config GridView DB
            gvDB.OptionsView.ShowGroupPanel = false;
            gvDB.OptionsFind.AlwaysVisible = true;
            gvDB.OptionsFind.FindNullPrompt = "Tìm kiếm...";
            pcINPUTTG.Visible = false; // Initially hide the time panel

            // Update button states based on initial load
            UpdateButtonStates();
            defaultToolTipController1.SetToolTip(lblThongBao, "Hãy sao lưu log gần nhất để tối ưu hóa khả năng phục hồi dữ liệu.");
        }

        private void UpdateButtonStates()
        {
            // Enable/disable buttons based on whether a database is selected in gvDB
            bool dbSelected = gvDB.FocusedRowHandle >= 0 && !string.IsNullOrWhiteSpace(_DATABASE_NAME);
            btnTaoDevice.Enabled = dbSelected;
            btnSaoLuu.Enabled = dbSelected;
            btnPhucHoi.Enabled = dbSelected && bdsDSBACKUP.Count > 0;
            ckbThoiGian.Enabled = dbSelected && bdsDSBACKUP.Count > 0; // Also depends on DB selection
        }

        private void gvDB_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                _DATABASE_NAME = gvDB.GetRowCellValue(e.FocusedRowHandle, "name")?.ToString();
                if (!string.IsNullOrWhiteSpace(_DATABASE_NAME))
                {
                    dB_NAMEToolStripTextBox.Text = _DATABASE_NAME;
                    LoadBackupList(_DATABASE_NAME);
                    if (bdsDSBACKUP.Count > 0)
                    {
                        gridViewDSBACKUP.FocusedRowHandle = 0;
                    }
                }
                else
                {
                    _DATABASE_NAME = null;
                    qLTVDataSet.sp_DanhSachBackup.Clear();
                }
            }
            else
            {
                _DATABASE_NAME = null;
                dB_NAMEToolStripTextBox.Text = "";
                qLTVDataSet.sp_DanhSachBackup.Clear();
            }
            UpdateButtonStates();
        }

        private void gridViewDBBACKUP_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "type")
            {
                switch (e.Value?.ToString())
                {
                    case "D":
                        e.DisplayText = "FULL (Sao lưu toàn bộ)";
                        break;
                    case "I":
                        e.DisplayText = "DIFFERENTIAL (Sao lưu khác biệt)";
                        break;
                    case "L":
                        e.DisplayText = "LOG (Nhật ký giao dịch)";
                        break;
                    default:
                        e.DisplayText = "Không xác định";
                        break;
                }
            }
        }

        private void LoadBackupList(string dbName)
        {
            try
            {
                this.sp_DanhSachBackupTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sp_DanhSachBackupTableAdapter.Fill(this.qLTVDataSet.sp_DanhSachBackup, dbName);

                if (bdsDSBACKUP.Count > 0)
                {
                    bdsDSBACKUP.Position = 0;
                }
                else
                {
                    XtraMessageBox.Show("Không có bản sao lưu nào trong cơ sở dữ liệu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("NO_FULL_BACKUP_FOUND"))
                {
                    XtraMessageBox.Show("Chưa có bản sao lưu FULL nào cho database " + _DATABASE_NAME + ".\nVui lòng thực hiện FULL backup trước khi thực hiện các thao tác khác.",
                        "Thiếu bản FULL Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            string dbName = dB_NAMEToolStripTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(dbName))
            {
                LoadBackupList(dbName);
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập hoặc chọn tên database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region *** XỬ LÝ CÁC SỰ KIỆN BUTTON_CLICK ****************
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var confirmResult = XtraMessageBox.Show(
                    "Bạn có chắc chắn muốn thoát trang backup-restore không?",
                    $"Xác Nhận Thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        private void btnTaoDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_DATABASE_NAME))
            {
                MessageBox.Show("Vui lòng chọn một cơ sở dữ liệu từ danh sách.", "Chưa chọn Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);
            try
            {
                using (FS_TaoDevice fsTaoDevice = new FS_TaoDevice(_DATABASE_NAME))
                {
                    fsTaoDevice.ShowDialog();
                }
            }
            finally
            {
                OverlayHelper.CloseOverlay(Program.handle);
            }
        }

        private void btnSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_DATABASE_NAME))
            {
                MessageBox.Show("Vui lòng chọn một cơ sở dữ liệu từ danh sách.", "Chưa chọn Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);
            try
            {
                using (FS_Backup fsBackup = new FS_Backup(_DATABASE_NAME))
                {
                    fsBackup.ExecuteBackupSuccess += () =>
                    {
                        LoadBackupList(_DATABASE_NAME);
                    };
                    fsBackup.ShowDialog();
                }
            }
            finally
            {
                OverlayHelper.CloseOverlay(Program.handle);
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_DATABASE_NAME))
            {
                XtraMessageBox.Show("Vui lòng chọn một cơ sở dữ liệu để phục hồi.", "Chưa chọn Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isPointInTimeRestore = ckbThoiGian.Checked;

            if (isPointInTimeRestore)
            {
                string deviceName = null;
                string deviceNameLog = null;

                var allBackups = (this.qLTVDataSet.sp_DanhSachBackup.AsEnumerable());

                var fullBackupRow = allBackups.FirstOrDefault(r => r.Field<string>("type") == "D");
                if (fullBackupRow != null)
                {
                    deviceName = fullBackupRow.Field<string>("device_name");
                }
                var logBackupRow = allBackups.FirstOrDefault(r => r.Field<string>("type") == "L");
                if (logBackupRow != null)
                {
                    deviceNameLog = logBackupRow.Field<string>("device_name");
                }


                if (string.IsNullOrEmpty(deviceName))
                {
                    XtraMessageBox.Show("Không tìm thấy device cho bản sao lưu FULL (type = 'D') trong danh sách.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(deviceNameLog))
                {
                    XtraMessageBox.Show("Không tìm thấy device cho bản sao lưu LOG (type = 'L') trong danh sách.\nVui lòng thực hiện BACKUP LOG và đảm bảo device được liệt kê!", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (dateTimeTGPHUCHOI.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn thời điểm cần phục hồi.", "Chưa chọn thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime restoreTime;
                if (dateTimeTGPHUCHOI.EditValue is DateTime dt)
                {
                    restoreTime = dt; // Giá trị đã ở múi giờ cục bộ (UTC+7)
                }
                else if (dateTimeTGPHUCHOI.EditValue is DateTimeOffset dto)
                {
                    restoreTime = dto.DateTime; // Lấy trực tiếp giá trị DateTime, đã ở múi giờ cục bộ
                }
                else
                {
                    XtraMessageBox.Show("Giá trị thời gian phục hồi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //DateTime restoreTimeUtc = restoreTime.ToUniversalTime();

                // SQL Server's STOPAT expects datetime in a format it understands, often close to ISO 8601.
                // Sending DateTime object directly to SqlParameter is usually fine.
                // The SQL script used CONVERT(..., 121) which is 'yyyy-mm-dd hh:mi:ss.mmm(24h)'

                string confirmMessagePITR = $"Bạn có chắc chắn muốn phục hồi CSDL '{_DATABASE_NAME}'\n" +
                                          $"từ device FULL/DIFF '{deviceName}'\n" +
                                          $"và device LOG '{deviceNameLog}'\n" +
                                          $"về thời điểm '{restoreTime:yyyy-MM-dd HH:mm:ss}' không?\n\n" +
                                          "Hành động này sẽ ghi đè lên CSDL hiện tại!";
                if (XtraMessageBox.Show(confirmMessagePITR, "Xác nhận Phục hồi Theo Thời Gian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_isNoTruncateOn)
                    {
                        // -------- ALL BACKUP LOG USE NO_TRUNCATE --------
                        ExecuteRestoreStopAt_Simplified(deviceName, deviceNameLog, restoreTime);
                    }
                    else
                    {
                        // ------- ALL BACKUP LOG DEFAULT --------
                        ExecuteRestoreStopAt(deviceName, deviceNameLog, restoreTime);
                    }
                }
            }
            else // Standard Restore
            {
                if (gridViewDSBACKUP.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn một bản sao lưu từ danh sách để phục hồi.", "Chưa chọn Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRowView selectedBackupRow = gridViewDSBACKUP.GetFocusedRow() as DataRowView;
                if (selectedBackupRow == null)
                {
                    XtraMessageBox.Show("Không thể lấy thông tin chi tiết của bản sao lưu đã chọn.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(selectedBackupRow["position"]?.ToString(), out int position))
                {
                    XtraMessageBox.Show("Không thể đọc vị trí (position) của bản sao lưu.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string backupType = selectedBackupRow["type"]?.ToString();
                string deviceName = selectedBackupRow["device_name"]?.ToString();
                DateTime backupStartDate = (DateTime)selectedBackupRow["backup_start_date"];

                if (string.IsNullOrWhiteSpace(backupType) || !"DI".Contains(backupType.ToUpper())) // Only D or I
                {
                    XtraMessageBox.Show("Loại sao lưu (type) không hợp lệ cho chế độ phục hồi này. Chỉ hỗ trợ FULL (D) hoặc DIFFERENTIAL (I).", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(deviceName))
                {
                    XtraMessageBox.Show("Không tìm thấy tên device cho bản sao lưu này.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string backupTypeText = gridViewDSBACKUP.GetFocusedRowCellDisplayText("type");
                string confirmMessageStandard = $"Bạn có chắc chắn muốn phục hồi CSDL '{_DATABASE_NAME}'\n" +
                                            $"từ bản sao lưu loại '{backupTypeText}'\n" +
                                            $"tạo lúc '{backupStartDate:yyyy-MM-dd HH:mm:ss}'\n" +
                                            $"(Vị trí {position} trên device '{deviceName}') không?\n\n" +
                                            "Hành động này sẽ ghi đè lên CSDL hiện tại!";
                if (XtraMessageBox.Show(confirmMessageStandard, "Xác nhận Phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {   // -------- Standard Restore -> FULL/DIFFERENTIAL --------
                    ExecuteStandardRestore(deviceName, backupType, position);
                }
            }
        }
        #endregion

        #region *** ALL STEP EXECUTE SQL RESSTORE FULL/DIFFERENTIAL *******
        private void ExecuteStandardRestore(string deviceName, string backupType, int position)
        {
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);

            if (Program.KetNoi() == 0) return; // Ensure connection is open
            try
            {
                Program.conn.ChangeDatabase("master"); // Switch to master for ALTER DATABASE
                StringBuilder sqlBatch = new StringBuilder();
                // Step 1: Đặt cơ sở dữ liệu về chế độ SINGLE_USER
                sqlBatch.AppendLine($"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");
                // Step 2: Xử lý theo loại khôi phục
                if (backupType == "D")
                {
                    sqlBatch.AppendLine($"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceName)} WITH FILE = {position}, REPLACE, RECOVERY;");
                }
                else if (backupType == "I")
                {
                    // Find the latest full backup position before this differential
                    string findFullBackupSql = $@"
                            SELECT TOP 1 position
                            FROM msdb.dbo.backupset
                            WHERE database_name = @DB_NAME
                                  AND type = 'D'
                                  AND position < @DiffPosition
                            ORDER BY backup_set_id DESC;";

                    int fullBackupPosition = -1;
                    using (SqlCommand findCmd = new SqlCommand(findFullBackupSql, Program.conn))
                    {
                        findCmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                        findCmd.Parameters.AddWithValue("@DiffPosition", position);
                        object result = findCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            fullBackupPosition = Convert.ToInt32(result);
                        }
                    }

                    if (fullBackupPosition == -1)
                    {
                        throw new Exception($"Không tìm thấy bản FULL backup hợp lệ có position < {position} cho database {_DATABASE_NAME} trên device {deviceName}.");
                    }

                    sqlBatch.AppendLine($"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceName)} WITH FILE = {fullBackupPosition}, REPLACE, NORECOVERY;");
                    sqlBatch.AppendLine($"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceName)} WITH FILE = {position}, RECOVERY;");
                }

                // Execute the batch for single_user and restore
                if (Program.ExecuteSqlNonQuery(sqlBatch.ToString()) != 0) return;
                OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null;

                XtraMessageBox.Show($"Phục hồi CSDL '{_DATABASE_NAME}' từ vị trí {position} trên device '{deviceName}' thành công!",
                                    "Phục hồi Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBackupList(_DATABASE_NAME);
            }
            catch (Exception ex)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle);
                XtraMessageBox.Show($"Lỗi khi thực hiện phục hồi:\n{ex.Message}\n\n" +
                                    $"DB: {_DATABASE_NAME}\nDevice: {deviceName}\nType: {backupType}\nPosition: {position}\n\n" +
                                    $"Kiểm tra quyền, trạng thái CSDL, và tính toàn vẹn của file backup.",
                                    "Lỗi Phục hồi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Step 4: Đặt cơ sở dữ liệu trở lại MULTI_USER
                // This needs to be executed regardless of success/failure of restore, if DB still exists
                try
                {
                    if (Program.conn.State == ConnectionState.Open)
                    {
                        string checkDbExistsSql = $"SELECT 1 FROM sys.databases WHERE name = '{_DATABASE_NAME}'";
                        bool dbExists = false;
                        using (SqlCommand checkCmd = new SqlCommand(checkDbExistsSql, Program.conn))
                        {
                            if (checkCmd.ExecuteScalar() != null) dbExists = true;
                        }
                        if (dbExists)
                        {
                            // Set MULTI_USER
                            string multiUserCmd = $"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET MULTI_USER;";
                            Program.ExecuteSqlNonQuery(multiUserCmd);
                            Program.conn.ChangeDatabase(_DATABASE_NAME);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đặt DB về MULTI_USER: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Program.conn.State == ConnectionState.Open)
                {
                    Program.conn.Close();
                }
            }
        }
        #endregion

        #region *** ALL STEP EXECUTE SQL RESSTORE WITH STOPAT - LOG USE NO_TRUNCATE *******
        private void ExecuteRestoreStopAt_Simplified(string deviceNameFull, string deviceNameLog, DateTime restoreTime)
        {
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);

            if (Program.KetNoi() == 0) return; // Ensure connection is open
            try
            {
                Program.conn.ChangeDatabase("master"); // Crucial for ALTER DATABASE and RESTORE

                // Step 1: Set SINGLE_USER
                string singleUserSql = $"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                ExecuteNonQuery(Program.conn, singleUserSql, 300); // 5 minutes for SINGLE_USER

                // Step 2: Restore Full Backup
                string restoreFullSql = $"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameFull)} WITH NORECOVERY, REPLACE;";
                ExecuteNonQuery(Program.conn, restoreFullSql, 1200); // 20 minutes for full restore

                // --- Log Restore Sequence (Simplified) ---
                int lastLogPosition = -1;

                // Step 3: Find POSITION of the log backup that *contains* the point in time
                string findLastLogSql = $@"
                            SELECT TOP 1 position
                            FROM msdb.dbo.backupset
                            WHERE database_name = @DB_NAME
                                  AND type = 'L'
                                  AND backup_finish_date >= @PointInTime
                            ORDER BY backup_finish_date ASC;"; // Get the earliest one that covers the time
                using (SqlCommand cmd = new SqlCommand(findLastLogSql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                    cmd.Parameters.AddWithValue("@PointInTime", restoreTime);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastLogPosition = Convert.ToInt32(result);
                    }
                }

                if (lastLogPosition == -1)
                {
                    throw new Exception($"Không tìm thấy bản LOG backup nào bao phủ thời điểm phục hồi {restoreTime:yyyy-MM-dd HH:mm:ss}. " +
                                        "Không thể hoàn tất phục hồi theo thời gian với STOPAT.");
                }

                // Step 4: Restore the final log with STOPAT and RECOVERY
                string stopAtFormatted = restoreTime.ToString("yyyy-MM-ddTHH:mm:ss.fff"); // SQL Server likes this format
                string restoreFinalLogSql = $"RESTORE LOG {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameLog)} WITH FILE = {lastLogPosition}, STOPAT = '{stopAtFormatted}', RECOVERY;";
                ExecuteNonQuery(Program.conn, restoreFinalLogSql, 1200); // 20 minutes for log restore

                // --- End of Simplified Log Restore Sequence ---

                OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null;

                XtraMessageBox.Show($"Phục hồi CSDL '{_DATABASE_NAME}' về thời điểm '{restoreTime:yyyy-MM-dd HH:mm:ss}' (Simplified) thành công!",
                                    "Phục hồi Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBackupList(_DATABASE_NAME); // Refresh the list of backups
            }
            catch (Exception ex)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null;
                XtraMessageBox.Show($"Lỗi khi thực hiện phục hồi theo thời gian (Simplified):\n{ex.Message}\n\n" +
                                    $"DB: {_DATABASE_NAME}\nThiết bị Full: {deviceNameFull}\nThiết bị Log: {deviceNameLog}\nThời điểm: {restoreTime:yyyy-MM-dd HH:mm:ss}\n\n" +
                                    $"Kiểm tra quyền, trạng thái CSDL, sự tồn tại của các bản backup, và tính toàn vẹn của file backup. " +
                                    "CSDL có thể đang ở trạng thái 'Restoring'.",
                                    "Lỗi Phục hồi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Step 5: Set MULTI_USER
                try
                {
                    if (Program.conn.State == ConnectionState.Open)
                    {
                        string checkDbOnlineSql = $"SELECT 1 FROM sys.databases WHERE name = @DB_NAME AND state_desc = 'ONLINE'";
                        bool dbOnline = false;
                        using (SqlCommand checkCmd = new SqlCommand(checkDbOnlineSql, Program.conn))
                        {
                            checkCmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                            if (checkCmd.ExecuteScalar() != null) dbOnline = true;
                        }

                        if (dbOnline)
                        {
                            string multiUserSql = $"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET MULTI_USER;";
                            ExecuteNonQuery(Program.conn, multiUserSql, 300); // 5 minutes for MULTI_USER
                        }
                        else
                        {
                            string dbStateSql = "SELECT state_desc FROM sys.databases WHERE name = @DB_NAME";
                            string currentState = "";
                            using (SqlCommand stateCmd = new SqlCommand(dbStateSql, Program.conn))
                            {
                                stateCmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                                object stateResult = stateCmd.ExecuteScalar();
                                if (stateResult != null) currentState = stateResult.ToString();
                            }
                            if (currentState == "RESTORING")
                            {
                                MessageBox.Show($"CSDL '{_DATABASE_NAME}' vẫn ở trạng thái 'RESTORING'. " +
                                                "Điều này có thể do lỗi hoặc quá trình phục hồi không hoàn tất đúng cách với RECOVERY. " +
                                                "Vui lòng kiểm tra thủ công.",
                                                "Cảnh báo trạng thái CSDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi đặt DB về MULTI_USER hoặc kiểm tra trạng thái: {ex.Message}");
                    MessageBox.Show($"Lỗi khi đặt DB '{_DATABASE_NAME}' về MULTI_USER: {ex.Message}. " +
                                    "Bạn có thể cần thực hiện thủ công.", "Lỗi Cuối Cùng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (Program.conn.State == ConnectionState.Open)
                    {
                        Program.conn.Close();
                    }
                }
            }

        }
        #endregion

        #region *** ALL STEP EXECUTE SQL RESSTORE WITH STOPAT - LOG USE TRUNCATE (DEFAULT) *******
        private void ExecuteRestoreStopAt(string deviceNameFullDiff, string deviceNameLog, DateTime restoreTime)
        {
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);

            if (Program.KetNoi() == 0) return;
            try
            {
                Program.conn.ChangeDatabase("master"); // Crucial for ALTER DATABASE and RESTORE

                // Step 1: Set SINGLE_USER
                string singleUserSql = $"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                ExecuteNonQuery(Program.conn, singleUserSql, 300);

                // --- Variable Declarations ---
                int fullBackupSetId = -1;
                int fullBackupPosition = -1;
                decimal fullLastLsn = 0; // NUMERIC(25,0) -> decimal in C#

                int diffBackupSetId = -1; // Use -1 to indicate not found initially
                int diffPosition = -1;
                DateTime? diffFinishDate = null;
                decimal? diffLastLsn = null; // Nullable decimal

                int lastLogBackupSetId = -1;
                int lastLogPosition = -1;

                // Step 2: Find Full backup
                string findFullSql = $@"
                        SELECT TOP 1
                            bs.backup_set_id, bs.position, bs.last_lsn
                        FROM msdb.dbo.backupset bs
                        WHERE bs.database_name = @DB_NAME
                              AND bs.type = 'D'
                              AND bs.backup_finish_date <= @PointInTime
                        ORDER BY bs.backup_finish_date DESC;";
                using (SqlCommand cmd = new SqlCommand(findFullSql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                    cmd.Parameters.AddWithValue("@PointInTime", restoreTime);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fullBackupSetId = reader.GetInt32(reader.GetOrdinal("backup_set_id"));
                            fullBackupPosition = reader.GetInt32(reader.GetOrdinal("position"));
                            fullLastLsn = reader.GetDecimal(reader.GetOrdinal("last_lsn"));
                        }
                    }
                }

                if (fullBackupPosition == -1)
                {
                    throw new Exception($"Không tìm thấy bản FULL backup phù hợp (trước hoặc tại {restoreTime:yyyy-MM-dd HH:mm:ss}) cho CSDL {_DATABASE_NAME}.");
                }

                // Step 3: Find Differential backup
                string findDiffSql = $@"
                            SELECT TOP 1
                                bs.backup_set_id, bs.position, bs.backup_finish_date, bs.last_lsn
                            FROM msdb.dbo.backupset bs
                            WHERE bs.database_name = @DB_NAME
                                  AND bs.type = 'I'
                                  AND bs.backup_set_id > @FullBackupSetId
                                  AND bs.backup_finish_date <= @PointInTime
                            ORDER BY bs.backup_finish_date DESC;";
                using (SqlCommand cmd = new SqlCommand(findDiffSql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                    cmd.Parameters.AddWithValue("@FullBackupSetId", fullBackupSetId);
                    cmd.Parameters.AddWithValue("@PointInTime", restoreTime);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            diffBackupSetId = reader.GetInt32(reader.GetOrdinal("backup_set_id"));
                            diffPosition = reader.GetInt32(reader.GetOrdinal("position"));
                            diffFinishDate = reader.GetDateTime(reader.GetOrdinal("backup_finish_date"));
                            diffLastLsn = reader.GetDecimal(reader.GetOrdinal("last_lsn"));
                        }
                    }
                }

                // Step 4: Adjust Diff if needed
                if (diffBackupSetId != -1 && diffFinishDate.HasValue && restoreTime < diffFinishDate.Value)
                {
                    diffBackupSetId = -1; // Effectively ignore this differential
                    diffPosition = -1;
                    diffLastLsn = null;
                }

                // Step 5: Restore Full
                string restoreFullSql = $"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameFullDiff)} WITH FILE = {fullBackupPosition}, NORECOVERY, REPLACE;";
                ExecuteNonQuery(Program.conn, restoreFullSql, 1800);

                // Step 6: Restore logs between Full and Differential (if Diff exists)
                if (diffBackupSetId != -1 && diffLastLsn.HasValue)
                {
                    string getLogsBeforeDiffSql = $@"
                            SELECT position
                            FROM msdb.dbo.backupset
                            WHERE database_name = @DB_NAME
                                  AND type = 'L'
                                  AND backup_set_id > @FullBackupSetId
                                  AND backup_set_id < @DiffBackupSetId
                                  AND first_lsn <= @DiffLastLsn
                                  AND last_lsn >= @FullLastLSN
                            ORDER BY backup_finish_date ASC;";
                    List<int> logsToRestore = GetLogPositions(Program.conn, getLogsBeforeDiffSql,
                        new SqlParameter("@DB_NAME", _DATABASE_NAME),
                        new SqlParameter("@FullBackupSetId", fullBackupSetId),
                        new SqlParameter("@DiffBackupSetId", diffBackupSetId),
                        new SqlParameter("@DiffLastLsn", diffLastLsn.Value),
                        new SqlParameter("@FullLastLSN", fullLastLsn)
                    );
                    RestoreLogsWithNoRecovery(Program.conn, deviceNameLog, logsToRestore);
                }

                // Step 7: Restore Differential if exists
                if (diffBackupSetId != -1 && diffPosition != -1)
                {
                    string restoreDiffSql = $"RESTORE DATABASE {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameFullDiff)} WITH FILE = {diffPosition}, NORECOVERY;";
                    ExecuteNonQuery(Program.conn, restoreDiffSql, 1800);
                }

                // Step 8: Find the log backup that *contains* the point in time for STOPAT
                string findLastLogSql = $@"
                            SELECT TOP 1 bs.backup_set_id, bs.position
                            FROM msdb.dbo.backupset bs
                            WHERE bs.database_name = @DB_NAME
                                  AND bs.type = 'L'
                                  AND bs.backup_finish_date >= @PointInTime
                            ORDER BY bs.backup_finish_date ASC;";
                using (SqlCommand cmd = new SqlCommand(findLastLogSql, Program.conn))
                {
                    cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                    cmd.Parameters.AddWithValue("@PointInTime", restoreTime);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastLogBackupSetId = reader.GetInt32(reader.GetOrdinal("backup_set_id"));
                            lastLogPosition = reader.GetInt32(reader.GetOrdinal("position"));
                        }
                    }
                }

                // Step 9: Check if final log was found
                if (lastLogBackupSetId == -1)
                {
                    throw new Exception("Không tìm thấy bản log phù hợp để khôi phục đến thời điểm yêu cầu.");
                }

                // Step 10: Restore logs after Differential (or Full if no Diff) up to (but not including) the LastLogBackupSet
                int startLogProcessingAfterBackupSetId = (diffBackupSetId != -1) ? diffBackupSetId : fullBackupSetId;
                // LSN to ensure continuity after the last major restore (Full or Diff)
                decimal relevantStartLsn = (diffLastLsn.HasValue) ? diffLastLsn.Value : fullLastLsn;


                string getLogsAfterDiffOrFullSql = $@"
                            SELECT position
                            FROM msdb.dbo.backupset
                            WHERE database_name = @DB_NAME
                                  AND type = 'L'
                                  AND backup_set_id > @StartLogBackupSetId
                                  AND backup_set_id < @LastLogBackupSetIdForStopAt
                                  AND first_lsn >= @RelevantStartLsn
                            ORDER BY backup_finish_date ASC;";
                List<int> logsToRestoreAfter = GetLogPositions(Program.conn, getLogsAfterDiffOrFullSql,
                    new SqlParameter("@DB_NAME", _DATABASE_NAME),
                    new SqlParameter("@StartLogBackupSetId", startLogProcessingAfterBackupSetId),
                    new SqlParameter("@LastLogBackupSetIdForStopAt", lastLogBackupSetId),
                    new SqlParameter("@RelevantStartLsn", relevantStartLsn)
                );
                RestoreLogsWithNoRecovery(Program.conn, deviceNameLog, logsToRestoreAfter);


                // Step 11: Restore the final log with STOPAT and RECOVERY
                string stopAtFormatted = restoreTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                string restoreFinalLogSql = $"RESTORE LOG {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameLog)} WITH FILE = {lastLogPosition}, STOPAT = '{stopAtFormatted}', RECOVERY;";
                ExecuteNonQuery(Program.conn, restoreFinalLogSql, 1200);

                OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null;

                XtraMessageBox.Show($"Phục hồi CSDL '{_DATABASE_NAME}' về thời điểm '{restoreTime:yyyy-MM-dd HH:mm:ss}' thành công!",
                                    "Phục hồi Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBackupList(_DATABASE_NAME);
            }
            catch (Exception ex)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null;
                XtraMessageBox.Show($"Lỗi khi thực hiện phục hồi theo thời gian:\n{ex.Message}\n\n" +
                                    $"DB: {_DATABASE_NAME}\nDevice Full/Diff: {deviceNameFullDiff}\nDevice Log: {deviceNameLog}\nTime: {restoreTime:yyyy-MM-dd HH:mm:ss}\n\n" +
                                    $"Kiểm tra và thử lại. CSDL có thể đang ở trạng thái 'Restoring'.",
                                    "Lỗi Phục hồi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Step 12: Set MULTI_USER (this should run regardless of transaction on msdb queries)
                try
                {
                    if (Program.conn.State == ConnectionState.Open) // Connection to master
                    {
                        string checkDbOnlineSql = $"SELECT 1 FROM sys.databases WHERE name = @DB_NAME AND state_desc = 'ONLINE'";
                        bool dbOnline = false;
                        using (SqlCommand checkCmd = new SqlCommand(checkDbOnlineSql, Program.conn))
                        {
                            checkCmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                            if (checkCmd.ExecuteScalar() != null) dbOnline = true;
                        }

                        if (dbOnline)
                        {
                            string multiUserSql = $"ALTER DATABASE {SqlQuoteName(_DATABASE_NAME)} SET MULTI_USER;";
                            ExecuteNonQuery(Program.conn, multiUserSql, 60);
                        }
                        else
                        {
                            // Query state again without relying on prior transaction
                            string dbStateSql = "SELECT state_desc FROM sys.databases WHERE name = @DB_NAME";
                            string currentState = "";
                            using (SqlCommand stateCmd = new SqlCommand(dbStateSql, Program.conn))
                            {
                                stateCmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                                object stateResult = stateCmd.ExecuteScalar();
                                if (stateResult != null) currentState = stateResult.ToString();
                            }
                            if (currentState == "RESTORING")
                            {
                                MessageBox.Show($"CSDL '{_DATABASE_NAME}' vẫn ở trạng thái 'RESTORING'. " +
                                                "Vui lòng kiểm tra thủ công.",
                                                "Cảnh báo trạng thái CSDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception finalEx)
                {
                    Console.WriteLine($"Lỗi khi đặt DB về MULTI_USER: {finalEx.Message}");
                }
                finally
                {
                    if (Program.conn.State == ConnectionState.Open)
                    {
                        Program.conn.Close();
                    }
                }
            }
        }
        #endregion

        #region *** HELPER METHODS  *******

        private void ExecuteNonQuery(SqlConnection conn, string sql, int timeoutSeconds)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = timeoutSeconds;
                cmd.ExecuteNonQuery();
            }
        }

        private List<int> GetLogPositions(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            List<int> positions = new List<int>();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        positions.Add(reader.GetInt32(reader.GetOrdinal("position")));
                    }
                }
            }
            return positions;
        }

        private void RestoreLogsWithNoRecovery(SqlConnection conn, string deviceNameLog, List<int> positions)
        {
            foreach (int logPos in positions)
            {
                string restoreLogSql = $"RESTORE LOG {SqlQuoteName(_DATABASE_NAME)} FROM {SqlQuoteName(deviceNameLog)} WITH FILE = {logPos}, NORECOVERY;";
                ExecuteNonQuery(conn, restoreLogSql, 1200);
            }
        }

        // Helper to quote SQL identifiers
        private string SqlQuoteName(string name)
        {
            return $"[{name.Replace("]", "]]")}]"; // Basic quoting
        }
        #endregion

        #region *** XỬ LÝ CHỌN THỜI ĐIỂM (STOPAT) PHỤC HỒI ********
        private DateTimeOffset _minAllowedTime = DateTimeOffset.MinValue;
        private DateTimeOffset _maxAllowedTime = DateTimeOffset.Now.AddMinutes(-1);
        private bool _isUpdating = false; // Biến để tránh vòng lặp sự kiện
        private void ckbThoiGian_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (ckbThoiGian.Checked)
            {
                pcINPUTTG.Visible = true;
                SetDateTimeOffsetConstraints();
            }
            else
            {
                pcINPUTTG.Visible = false;
            }
        }

        private void SetDateTimeOffsetConstraints()
        {
            // Lấy dữ liệu từ gridViewDSBACKUP
            if (gridViewDSBACKUP.DataSource != null)
            {
                try
                {
                    // Lấy số lượng dòng trong grid view
                    int rowCount = gridViewDSBACKUP.RowCount;

                    // Duyệt qua các dòng để tìm type='D' với position=1 và type='L'
                    for (int i = 0; i < rowCount; i++)
                    {
                        // Lấy giá trị của cột type, backup_start_date và position tại dòng i
                        string backupType = gridViewDSBACKUP.GetRowCellValue(i, "type")?.ToString();
                        DateTime backupStartDate = (DateTime)gridViewDSBACKUP.GetRowCellValue(i, "backup_start_date");
                        int position = Convert.ToInt32(gridViewDSBACKUP.GetRowCellValue(i, "position"));

                        // Sử dụng múi giờ cục bộ (UTC+7:00)
                        var localTimeZone = TimeZoneInfo.Local;
                        var backupDateOffset = new DateTimeOffset(backupStartDate, localTimeZone.BaseUtcOffset);

                        // Xử lý theo loại backup
                        if (backupType == "D" && position == 1)
                        {
                            // Gán _minAllowedTime từ full backup với position=1
                            _minAllowedTime = backupDateOffset.AddSeconds(30);
                        }
                        else if (backupType == "L")
                        {
                            // Gán _maxAllowedTime từ log backup với position=1
                            _maxAllowedTime = backupDateOffset.AddMinutes(-1);
                        }
                    }

                    // Đảm bảo _minAllowedTime không vượt quá _maxAllowedTime
                    if (_minAllowedTime > _maxAllowedTime)
                    {
                        _minAllowedTime = _maxAllowedTime;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi đọc dữ liệu từ gridViewDSBACKUP: " + ex.Message);
                }
            }

            // Kiểm tra giá trị hiện tại, nhưng không đặt lại nếu đang trong quá trình cập nhật
            if (!_isUpdating && dateTimeTGPHUCHOI.EditValue != null)
            {
                DateTimeOffset currentValue;

                // Kiểm tra kiểu của EditValue
                if (dateTimeTGPHUCHOI.EditValue is DateTime dt)
                {
                    // Nếu là DateTime, gán múi giờ cục bộ (UTC+7:00)
                    currentValue = new DateTimeOffset(dt, TimeZoneInfo.Local.BaseUtcOffset);
                }
                else if (dateTimeTGPHUCHOI.EditValue is DateTimeOffset dto)
                {
                    // Nếu là DateTimeOffset, chuyển về múi giờ cục bộ (UTC+7:00)
                    currentValue = new DateTimeOffset(dto.DateTime, TimeZoneInfo.Local.BaseUtcOffset);
                }
                else
                {
                    return; // Bỏ qua nếu không phải kiểu hợp lệ
                }

                if (currentValue < _minAllowedTime)
                {
                    _isUpdating = true;
                    dateTimeTGPHUCHOI.EditValue = _minAllowedTime;
                    _isUpdating = false;
                }
                else if (currentValue > _maxAllowedTime)
                {
                    _isUpdating = true;
                    dateTimeTGPHUCHOI.EditValue = _maxAllowedTime;
                    _isUpdating = false;
                }
            }
        }

        private void dateTimeTGPHUCHOI_EditValueChanged(object sender, EventArgs e)
        {
            if (_isUpdating)
                return; // Tránh vòng lặp sự kiện

            DateTimeOffset selected;

            // Kiểm tra kiểu của EditValue
            if (dateTimeTGPHUCHOI.EditValue is DateTime dt)
            {
                // Nếu là DateTime, gán múi giờ cục bộ (UTC+7:00)
                selected = new DateTimeOffset(dt, TimeZoneInfo.Local.BaseUtcOffset);
            }
            else if (dateTimeTGPHUCHOI.EditValue is DateTimeOffset dto)
            {
                // Nếu là DateTimeOffset, chuyển về múi giờ cục bộ (UTC+7:00)
                selected = new DateTimeOffset(dto.DateTime, TimeZoneInfo.Local.BaseUtcOffset);
            }
            else
            {
                return; // Bỏ qua nếu không phải kiểu hợp lệ
            }

            if (selected < _minAllowedTime)
            {
                string formattedMinTime = _minAllowedTime.ToString("dd/MM/yyyy HH:mm:ss");
                MessageBox.Show($"Không được chọn trước thời điểm {formattedMinTime}.", "Cảnh báo");

                _isUpdating = true;
                dateTimeTGPHUCHOI.EditValue = _minAllowedTime;
                _isUpdating = false;
            }
            else if (selected > _maxAllowedTime)
            {
                string formattedMaxTime = _maxAllowedTime.ToString("dd/MM/yyyy HH:mm:ss");
                MessageBox.Show($"Không được chọn sau thời điểm {formattedMaxTime}.", "Cảnh báo");

                _isUpdating = true;
                dateTimeTGPHUCHOI.EditValue = _maxAllowedTime;
                _isUpdating = false;
            }
        }

        private void gridViewDBBACKUP_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetDateTimeOffsetConstraints();
        }

        private void gridViewDSBACKUP_DataSourceChanged(object sender, EventArgs e)
        {
            SetDateTimeOffsetConstraints();
            if (bdsDSBACKUP.Count > 0)
            {
                btnPhucHoi.Enabled = true;
                ckbThoiGian.Enabled = true;
            }
        }
        #endregion
    }
}
