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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AppLibrary
{
    public partial class FormBackupRestore : DevExpress.XtraEditors.XtraForm
    {
        public FormBackupRestore()
        {
            InitializeComponent();
        }
        private string _DATABASE_NAME;

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
            ckbThoiGian.Enabled = bdsDSBACKUP.Count > 0;
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
                    SetDateTimeOffsetConstraints();
                    if (bdsDSBACKUP.Count > 0) // Select first backup row if available
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

            // Update button states whenever the focused DB changes
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
            {   // ____TABLE BACKUP FULL AND DIFFERENTIAL____
                this.sp_DanhSachBackupTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sp_DanhSachBackupTableAdapter.Fill(this.qLTVDataSet.sp_DanhSachBackup, dbName);
                if (bdsDSBACKUP.Count > 0) { bdsDSBACKUP.Position = 0; }

                // ____TABLE BACKUP LOG____
                //this.sp_DanhSachBackupLogTableAdapter.Connection.ConnectionString = Program.connstr;
                //this.sp_DanhSachBackupLogTableAdapter.Fill(this.qLTVDataSet.sp_DanhSachBackupLog, dbName);
                //if (bdsDSBACKUP_LOG.Count > 0) { bdsDSBACKUP_LOG.Position = 0;}
                if (bdsDSBACKUP.Count == 0)
                {
                    XtraMessageBox.Show("Không có bản sao lưu nào trong cơ sở dữ liệu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SetDateTimeOffsetConstraints();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải danh sách backup: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            // This button might be redundant if LoadBackupList is called on DB selection change
            // But keep it if explicit refresh is desired
            string dbName = dB_NAMEToolStripTextBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(dbName))
            {
                LoadBackupList(dbName);
                SetDateTimeOffsetConstraints();
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập hoặc chọn tên database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTaoDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_DATABASE_NAME))
            {
                MessageBox.Show("Vui lòng chọn một cơ sở dữ liệu từ danh sách.", "Chưa chọn Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mở FORM TẠO DEVICE và truyền tên database
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
            // Mở form BACKUP và truyền tên database
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);
            try
            {
                using (FS_Backup fsBackup = new FS_Backup(_DATABASE_NAME))
                {
                    fsBackup.ExecuteBackupSuccess += () =>
                    {
                        // Refresh the backup list after successful backup
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

        // ========== IMPLEMENTATION FOR RESTORE BUTTON ==========
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // --- Basic Validation ---
            if (string.IsNullOrWhiteSpace(_DATABASE_NAME))
            {
                XtraMessageBox.Show("Vui lòng chọn một cơ sở dữ liệu để phục hồi.", "Chưa chọn Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine restore mode based on the checkbox
            bool isPointInTimeRestore = ckbThoiGian.Checked;

            // --- Point-In-Time Restore Logic ---
            if (isPointInTimeRestore)
            {   
                string deviceName = null;
                string deviceNameLog = null;
                DateTime restoreTime;
                if (gridViewDSBACKUP.DataSource != null)
                {
                    try
                    {
                        // Lấy số lượng dòng trong grid view
                        int rowCount = gridViewDSBACKUP.RowCount;
                        // Duyệt qua các dòng để tìm type = 'D' và type = 'L'
                        for (int i = 0; i < rowCount; i++)
                        {
                            // Lấy giá trị của cột type và device_name tại dòng i
                            string backupType = gridViewDSBACKUP.GetRowCellValue(i, "type")?.ToString();
                            string deviceNameValue = gridViewDSBACKUP.GetRowCellValue(i, "device_name")?.ToString();

                            // Gán giá trị cho deviceName và deviceNameLog
                            if (backupType == "D")
                            {
                                deviceName = deviceNameValue;
                            }
                            else if (backupType == "L")
                            {
                                deviceNameLog = deviceNameValue;
                            }
                        }

                        // Kiểm tra xem có tìm thấy deviceName và deviceNameLog không
                        if (string.IsNullOrEmpty(deviceName))
                        {
                            XtraMessageBox.Show("Không tìm thấy bản sao lưu FULL (type = 'D') trong danh sách.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (string.IsNullOrEmpty(deviceNameLog))
                        {
                            XtraMessageBox.Show("Không tìm thấy bản sao lưu LOG (type = 'L') trong danh sách.\nVui lòng thực hiện BACKUP LOG!", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // Kiểm tra xem dateTimeTGPHUCHOI.EditValue có null không
                        if (dateTimeTGPHUCHOI.EditValue == null)
                        {
                            XtraMessageBox.Show("Vui lòng chọn thời điểm cần phục hồi.", "Chưa chọn thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể lấy thông tin chi tiết của bản sao lưu đã chọn.\n" + ex.Message, "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không có dữ liệu trong danh sách sao lưu.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra kiểu của EditValue và chuyển đổi để lấy restoreTime
                if (dateTimeTGPHUCHOI.EditValue is DateTime dt)
                {
                    restoreTime = dt; // Nếu là DateTime, sử dụng trực tiếp
                }
                else if (dateTimeTGPHUCHOI.EditValue is DateTimeOffset dto)
                {
                    // Chuyển chính xác về múi giờ local
                    restoreTime = TimeZoneInfo.ConvertTime(dto.UtcDateTime, TimeZoneInfo.Local);
                }
                else
                {
                    throw new InvalidOperationException("dateTimeTGPHUCHOI.EditValue phải là DateTime hoặc DateTimeOffset.");
                }
                DateTime restoreTimeUtc = restoreTime.ToUniversalTime();

                // Confirmation dialog
                string confirmMessagePITR = $"Bạn có chắc chắn muốn phục hồi CSDL '{_DATABASE_NAME}'\n" +
                                          $"từ device FULL '{deviceName}'\n" +
                                          $"và device LOG '{deviceNameLog}'\n" +
                                          $"về thời điểm '{restoreTimeUtc:yyyy-MM-dd HH:mm:ss}' không?\n\n" +
                                          "Hành động này sẽ ghi đè lên CSDL hiện tại!";
                if (XtraMessageBox.Show(confirmMessagePITR, "Xác nhận Phục hồi Theo Thời Gian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ExecuteRestoreOverTime(deviceName, deviceNameLog, restoreTimeUtc);
                }
            }
            // --- Standard Restore Logic (Full/Diff/Log) ---
            else
            {
                // Validate backup selection in the grid
                if (gridViewDSBACKUP.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn một bản sao lưu từ danh sách để phục hồi.", "Chưa chọn Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get data from the selected row in gridViewDBBACKUP
                DataRowView selectedBackupRow = gridViewDSBACKUP.GetFocusedRow() as DataRowView;
                if (selectedBackupRow == null)
                {
                    XtraMessageBox.Show("Không thể lấy thông tin chi tiết của bản sao lưu đã chọn.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Safely extract data
                if (!int.TryParse(selectedBackupRow["position"]?.ToString(), out int position))
                {
                    XtraMessageBox.Show("Không thể đọc vị trí (position) của bản sao lưu.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string backupType = selectedBackupRow["type"]?.ToString();
                string deviceName = selectedBackupRow["device_name"]?.ToString(); // Get device name from the backup list grid
                DateTime backupStartDate = (DateTime)selectedBackupRow["backup_start_date"]; // For confirmation message

                // Validate extracted data
                if (string.IsNullOrWhiteSpace(backupType) || !"DI".Contains(backupType)) // Check if type is valid
                {
                    XtraMessageBox.Show("Loại sao lưu (type) không hợp lệ.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ("L".Contains(backupType))
                {
                    XtraMessageBox.Show("Không hỗ trợ phục hồi bản sao lưu LOG (type = 'L') trong chế độ này.\nVui lòng chọn loại backup khác.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else  // Check if device name is valid
                {
                    if (string.IsNullOrWhiteSpace(deviceName))
                    {
                        XtraMessageBox.Show("Không tìm thấy tên device cho bản sao lưu này.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Confirmation dialog
                    string backupTypeText = gridViewDSBACKUP.GetFocusedRowCellDisplayText("type"); // Get user-friendly text
                    string confirmMessageStandard = $"Bạn có chắc chắn muốn phục hồi CSDL '{_DATABASE_NAME}'\n" +
                                                $"từ bản sao lưu loại '{backupTypeText}'\n" +
                                                $"tạo lúc '{backupStartDate:yyyy-MM-dd HH:mm:ss}'\n" +
                                                $"(Vị trí {position} trên device '{deviceName}') không?\n\n" +
                                                "Hành động này sẽ ghi đè lên CSDL hiện tại!";
                    if (XtraMessageBox.Show(confirmMessageStandard, "Xác nhận Phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ExecuteStandardRestore(deviceName, backupType, position);
                    }
                }
            }
        }

        // --- Helper Method for Standard Restore Execution ---
        private void ExecuteStandardRestore(string deviceName, string backupType, int position)
        {
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);
            try
            {
                if(Program.KetNoi() == 0) return; // Ensure connection is established
                Program.conn.ChangeDatabase("tempdb");
                    using (SqlCommand cmd = new SqlCommand("sp_Restore", Program.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Set command timeout (e.g., 10 minutes) as restores can be long
                        cmd.CommandTimeout = 600;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                        cmd.Parameters.AddWithValue("@DEVICE_NAME", deviceName);
                        cmd.Parameters.AddWithValue("@TYPE", backupType); // Pass 'D', 'I'
                        cmd.Parameters.AddWithValue("@POSITION", position);

                        // Execute the restore command
                        cmd.ExecuteNonQuery();
                    }
                // quay lại DB gốc (nếu nó đã được phục hồi thành công)
                Program.conn.ChangeDatabase(_DATABASE_NAME);
                Program.conn.Close();

                // Close busy indicator on success
                OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null; // Reset handle

                XtraMessageBox.Show($"Phục hồi CSDL '{_DATABASE_NAME}' từ vị trí {position} trên device '{deviceName}' thành công!",
                                    "Phục hồi Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Refresh data if needed after restore
                LoadBackupList(_DATABASE_NAME);
            }
            catch (SqlException sqlEx)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle); // Ensure overlay is closed on error
                // Provide detailed SQL error
                XtraMessageBox.Show($"Lỗi SQL khi thực hiện phục hồi:\n{sqlEx.Message}\n\n" +
                                    $"SP: sp_Restore\nDB: {_DATABASE_NAME}\nDevice: {deviceName}\nType: {backupType}\nPosition: {position}\n\n" +
                                    $"Kiểm tra quyền thực thi SP, trạng thái CSDL, và tính toàn vẹn của file backup.",
                                    "Lỗi Phục hồi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle); // Ensure overlay is closed on error
                                                                        // Provide general error
                XtraMessageBox.Show($"Lỗi không mong muốn khi thực hiện phục hồi:\n{ex.Message}",
                                   "Lỗi Chương Trình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- Helper Method for Point-in-Time Restore Execution ---
        private void ExecuteRestoreOverTime(string deviceName, string deviceNameLog, DateTime restoreTime)
        {
            Program.handle = OverlayHelper.ShowOverlay(Program.CurrentMainForm);
            try
            {
                using (SqlConnection conn = new SqlConnection(Program.connstr))
                {
                    conn.Open();
                    conn.ChangeDatabase("tempdb");
                    using (SqlCommand cmd = new SqlCommand("sp_RestoreOverTime", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Set command timeout (e.g., 10 minutes)
                        cmd.CommandTimeout = 600;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@DB_NAME", _DATABASE_NAME);
                        cmd.Parameters.AddWithValue("@DEVICE_NAME", deviceName);
                        cmd.Parameters.AddWithValue("@DEVICE_NAME_LOG", deviceNameLog);
                        cmd.Parameters.AddWithValue("@POINT_IN_TIME_RECOVERY", restoreTime);

                        // Execute the restore command
                        cmd.ExecuteNonQuery();
                    }
                    // quay lại DB gốc (nếu nó đã được phục hồi thành công)
                    conn.ChangeDatabase(_DATABASE_NAME);
                }
                // Close busy indicator on success
                OverlayHelper.CloseOverlay(Program.handle);
                Program.handle = null; // Reset handle

                XtraMessageBox.Show($"Phục hồi CSDL '{_DATABASE_NAME}' về thời điểm '{restoreTime:yyyy-MM-dd HH:mm:ss}' từ device '{deviceName}' thành công!",
                                    "Phục hồi Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Refresh data if needed after restore
                LoadBackupList(_DATABASE_NAME);
            }
            catch (SqlException sqlEx)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle); // Ensure overlay is closed on error
                // Provide detailed SQL error
                XtraMessageBox.Show($"Lỗi SQL khi thực hiện phục hồi theo thời gian:\n{sqlEx.Message}\n\n" +
                                    $"SP: sp_RestoreOverTime\nDB: {_DATABASE_NAME}\nDevice: {deviceName}\nTime: {restoreTime:yyyy-MM-dd HH:mm:ss}\n\n" +
                                    $"Kiểm tra quyền thực thi SP, trạng thái CSDL, sự tồn tại của bản Full và Log backup cần thiết trên device, và tính toàn vẹn của file backup.",
                                    "Lỗi Phục hồi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle); // Ensure overlay is closed on error
                // Provide general error
                XtraMessageBox.Show($"Lỗi không mong muốn khi thực hiện phục hồi theo thời gian:\n{ex.Message}",
                                   "Lỗi Chương Trình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- End Implementation for Restore Button ---

        private void ckbThoiGian_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private DateTimeOffset _minAllowedTime = DateTimeOffset.MinValue;
        private DateTimeOffset _maxAllowedTime = DateTimeOffset.Now.AddMinutes(-1);
        private bool _isUpdating = false; // Biến để tránh vòng lặp sự kiện

        private void SetDateTimeOffsetConstraints()
        {
            // Thiết lập giá trị mặc định
            _minAllowedTime = DateTimeOffset.MinValue;
            _maxAllowedTime = DateTimeOffset.Now.AddMinutes(-1);

            // Lấy dữ liệu từ gridViewDSBACKUP
            if (gridViewDSBACKUP.DataSource != null)
            {
                try
                {
                    // Lấy số lượng dòng trong grid view
                    int rowCount = gridViewDSBACKUP.RowCount;
                    int maxDifferentialPosition = -1;
                    DateTimeOffset? latestDifferentialBackupTime = null;
                    DateTimeOffset? latestFullBackupTime = null;

                    // Duyệt qua các dòng để tìm type = 'D', 'I', và 'L'
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
                        if (backupType == "D")
                        {
                            // Lưu thời gian của full backup để sử dụng nếu không có differential backup
                            latestFullBackupTime = backupDateOffset;
                        }
                        else if (backupType == "I")
                        {
                            // Theo dõi bản differential backup có position lớn nhất
                            if (position > maxDifferentialPosition)
                            {
                                maxDifferentialPosition = position;
                                latestDifferentialBackupTime = backupDateOffset;
                            }
                        }
                        else if (backupType == "L")
                        {
                            // Cập nhật _maxAllowedTime từ log backup
                            _maxAllowedTime = backupDateOffset.AddMinutes(-1);
                        }
                    }

                    // Xác định _minAllowedTime
                    if (latestDifferentialBackupTime.HasValue)
                    {
                        // Nếu có differential backup, lấy thời gian từ differential backup có position lớn nhất + 1 giây
                        _minAllowedTime = latestDifferentialBackupTime.Value.AddSeconds(1);
                    }
                    else if (latestFullBackupTime.HasValue)
                    {
                        // Nếu không có differential backup, lấy thời gian từ full backup + 1 giây
                        _minAllowedTime = latestFullBackupTime.Value.AddSeconds(1);
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
                XtraMessageBox.Show($"Không được chọn trước thời điểm {formattedMinTime}.", "Cảnh báo");

                _isUpdating = true;
                dateTimeTGPHUCHOI.EditValue = _minAllowedTime;
                _isUpdating = false;
            }
            else if (selected > _maxAllowedTime)
            {
                string formattedMaxTime = _maxAllowedTime.ToString("dd/MM/yyyy HH:mm:ss");
                XtraMessageBox.Show($"Không được chọn sau thời điểm {formattedMaxTime}.", "Cảnh báo");

                _isUpdating = true;
                dateTimeTGPHUCHOI.EditValue = _maxAllowedTime;
                _isUpdating = false;
            }
        }

        
        private void gridViewDBBACKUP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetDateTimeOffsetConstraints();
        }
        private void lblThongBao_MouseHover(object sender, EventArgs e)
        {
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
    }
}