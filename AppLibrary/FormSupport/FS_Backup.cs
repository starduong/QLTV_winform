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
using AppLibrary.ClassSupport; // OverlayHelper
using System.Data.SqlClient;

namespace AppLibrary.FormSupport
{
    // Form for creating database backups (Full, Differential, Transaction Log).
    public partial class FS_Backup : DevExpress.XtraEditors.XtraForm
    {
        #region Helper Class: BackupOptions
        private class BackupOptions
        {
            public string DatabaseName { get; set; }
            public string BackupName { get; set; }
            public string Description { get; set; }
            public string DeviceName { get; set; }
            public bool IsDifferential { get; set; }
            public bool IsTransactionLog { get; set; }
        }
        #endregion

        private readonly string _databaseName; // truyền từ FormBackupRestore _ 

        #region Constructor
        public FS_Backup(string databaseName)
        {
            InitializeComponent();
            this._databaseName = databaseName;

            // Ensure a database name was provided.
            if (string.IsNullOrWhiteSpace(this._databaseName))
            {
                XtraMessageBox.Show("Không có tên cơ sở dữ liệu nào được cung cấp.", "Lỗi Khởi Tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers: Form Load / Closing
        private void FS_Backup_Load(object sender, EventArgs e)
        {   // If constructor detected an invalid database name, close the form immediately.
            if (string.IsNullOrWhiteSpace(_databaseName))
            {
                this.BeginInvoke(new Action(this.Close)); // Close safely after Load completes.
                return;
            }

            // --- Initialize UI ---
            txtDBName.Text = _databaseName; // Display the database name (read-only)

            try
            {
                // Load available backup devices into the ComboBox
                this.sYSBACKUP_DEVICETableAdapter.Connection.ConnectionString = Program.connstr;
                this.sYSBACKUP_DEVICETableAdapter.Fill(this.qLTVDataSet.SYSBACKUP_DEVICE);
                if (cbDeviceName.Items.Count == 0)
                {
                    XtraMessageBox.Show("Không tìm thấy thiết bị backup nào được cấu hình trong hệ thống (SYSBACKUP_DEVICE).\nVui lòng tạo thiết bị backup trước.",
                                       "Thiếu Thiết Bị Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnOk.Enabled = false;
                }
                else
                {
                    cbDeviceName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi tải danh sách thiết bị backup: {ex.Message}\nXem chi tiết lỗi trong log hoặc liên hệ quản trị viên.",
                                   "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOk.Enabled = false;
            }
            cbBackupType.SelectedIndex = 0; // Set default backup type to "Full" 
            UpdateDefaultBackupName();
        }

        private void FS_Backup_FormClosing(object sender, FormClosingEventArgs e)
        {   // Close the overlay helper if it's active (specific to this application's framework)
            if (Program.handle != null)
            {
                OverlayHelper.CloseOverlay(Program.handle);
            }
        }
        #endregion

        #region Event Handlers: Control Value Changes
        private void cbBackupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDefaultBackupName();
        }
        private void UpdateDefaultBackupName()
        {
            string backupType = cbBackupType.SelectedItem?.ToString();
            // Only update if a valid type is selected and database name is known.
            if (!string.IsNullOrEmpty(_databaseName) && !string.IsNullOrEmpty(backupType))
            {
                // Format: DatabaseName-Type Database Backup (e.g., QLTV-Full Database Backup)
                txtNameBK.Text = $"{_databaseName}-{backupType} Database Backup";
            }
        }
        #endregion

        #region Event Handlers: Button Clicks

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // --- 1. Input Validation ---
            if (!ValidateInputs()) { return; }

            // --- 2. Build Backup Options Object ---
            BackupOptions options;
            try
            {
                options = BuildBackupOptions();
            }
            catch (InvalidOperationException ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi Cấu Hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 3. Prerequisite Checks ---
            if (options.IsDifferential || options.IsTransactionLog)
            {
                // Use the improved CheckForFullBackup method below
                if (!CheckForFullBackupUsingOwnConnection(options.DatabaseName))
                {
                    string backupTypeName = options.IsDifferential ? "Differential" : "Transaction Log";
                    XtraMessageBox.Show($"Không tìm thấy bản Full Backup nào cho cơ sở dữ liệu '{options.DatabaseName}'.\n" +
                                        $"Bạn cần tạo một bản Full Backup trước khi tạo bản {backupTypeName} Backup.",
                                        "Yêu cầu Full Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // --- 3b. Confirmation for Operations Using INIT ---
            string selectedBackupType = cbBackupType.SelectedItem?.ToString();
            // Check if the selected type will result in using INIT (Full or Transaction log)
            if (selectedBackupType == "Full" || selectedBackupType == "Transaction log")
            {
                var confirmResult = XtraMessageBox.Show(
                    $"Bạn đã chọn loại backup '{selectedBackupType}'. Thao tác này sẽ sử dụng tùy chọn 'INIT'.\n" + // Explain INIT is used
                    $"Điều này sẽ XÓA TẤT CẢ các bản backup hiện có trên thiết bị '{options.DeviceName}' và bắt đầu một bộ backup mới.\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    $"Xác Nhận Ghi Đè (INIT) cho {selectedBackupType} Backup", // Title indicates the type
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2 // Default to No
                );

                if (confirmResult == DialogResult.No)
                {
                    return; // User cancelled
                }
                // User confirmed Yes, proceed.
            }
            // No confirmation needed for Differential (which uses NOINIT)

            // --- 4. Generate T-SQL Script ---
            string sqlScript;
            try
            {
                sqlScript = options.IsTransactionLog
                    ? GenerateLogBackupScript(options)      // Will use INIT internally now
                    : GenerateDataBackupScript(options);    // Will use INIT or NOINIT internally now
                if (string.IsNullOrEmpty(sqlScript))
                {
                    XtraMessageBox.Show("Không thể tạo lệnh backup.", "Lỗi Nội Bộ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                XtraMessageBox.Show($"Lỗi cấu hình backup khi tạo script: {ex.Message}", "Lỗi Script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi không mong muốn khi tạo script backup: {ex.Message}", "Lỗi Script", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 5. Execute Backup ---
            ExecuteBackupScript(sqlScript, options);
        }

        #endregion

        #region Helper Methods: Input Validation, Option Building, Prerequisite Checks
        private bool ValidateInputs()
        {
            // Check if a backup device is selected
            if (cbDeviceName.SelectedItem == null || cbDeviceName.SelectedValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn một thiết bị backup từ danh sách.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDeviceName.Focus();
                return false;
            }

            // Check if a backup name is provided
            if (string.IsNullOrWhiteSpace(txtNameBK.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên cho bản backup.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameBK.Focus();
                return false;
            }

            // Check if a backup type is selected
            if (cbBackupType.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn loại backup (Full, Differential, Transaction Log).", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbBackupType.Focus();
                return false;
            }

            return true;
        }

        private BackupOptions BuildBackupOptions()
        {
            string backupType = cbBackupType.SelectedItem?.ToString();
            object selectedDeviceValue = cbDeviceName.SelectedValue;

            // These should have been caught by ValidateInputs, but double-check defensively.
            if (string.IsNullOrEmpty(backupType))
                throw new InvalidOperationException("Loại backup chưa được chọn.");
            if (selectedDeviceValue == null)
                throw new InvalidOperationException("Thiết bị backup chưa được chọn.");

            var options = new BackupOptions
            {
                DatabaseName = this._databaseName,
                BackupName = txtNameBK.Text.Trim(), // Trim whitespace
                Description = txtDescription.Text.Trim(), // Trim whitespace
                DeviceName = selectedDeviceValue.ToString(),
                IsDifferential = (backupType == "Differential"),
                IsTransactionLog = (backupType == "Transaction log"),
            };
            return options;
        }

        private bool CheckForFullBackupUsingOwnConnection(string databaseName)
        {
            bool fullBackupExists = false;
            string checkSql = @"SELECT TOP 1 1 FROM msdb.dbo.backupset
                        WHERE database_name = @DatabaseName AND type = 'D';";

            try
            {
                // Use 'using' for connection and command to ensure disposal
                using (SqlConnection conn = new SqlConnection(Program.connstr)) // Use connection string
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@DatabaseName", databaseName);
                    conn.Open(); // Open the connection for this check
                    object result = checkCmd.ExecuteScalar();
                    fullBackupExists = (result != null && result != DBNull.Value);
                    // Connection automatically closed by 'using' block
                }
            }
            catch (SqlException sqlEx)
            {
                XtraMessageBox.Show($"Lỗi SQL khi kiểm tra Full Backup: {sqlEx.Message}\n" +
                                    "Kiểm tra quyền truy cập msdb.",
                                    "Lỗi Kiểm Tra Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi không mong muốn khi kiểm tra Full Backup: {ex.Message}",
                                    "Lỗi Kiểm Tra Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return fullBackupExists;
        }

        #endregion

        #region Helper Methods: T-SQL Generation
        private string GenerateDataBackupScript(BackupOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.DatabaseName))
                throw new ArgumentException("Tên cơ sở dữ liệu không được để trống.");
            if (string.IsNullOrWhiteSpace(options.DeviceName))
                throw new ArgumentException("Tên thiết bị backup không được để trống.");

            var script = new StringBuilder();
            script.Append($"BACKUP DATABASE [{options.DatabaseName}] ");
            script.Append($"TO [{options.DeviceName}] ");

            var withOptions = new List<string>();

            if (options.IsDifferential)
            {
                withOptions.Add("DIFFERENTIAL");
            }
            if (!string.IsNullOrWhiteSpace(options.BackupName))
            {
                withOptions.Add($"NAME = N'{options.BackupName.Replace("'", "''")}'");
            }
            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                withOptions.Add($"DESCRIPTION = N'{options.Description.Replace("'", "''")}'");
            }

            // --- MODIFIED HERE ---
            // Automatically set INIT for Full, NOINIT for Differential
            withOptions.Add(options.IsDifferential ? "NOINIT" : "INIT");
            // ---------------------

            //withOptions.Add("COMPRESSION");
            withOptions.Add("STATS = 10");

            if (withOptions.Any())
            {
                script.Append("WITH ");
                script.Append(string.Join(", ", withOptions));
            }
            script.Append(";");
            return script.ToString();
        }
        private string GenerateLogBackupScript(BackupOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.DatabaseName))
                throw new ArgumentException("Tên cơ sở dữ liệu không được để trống cho backup log.");
            if (string.IsNullOrWhiteSpace(options.DeviceName))
                throw new ArgumentException("Tên thiết bị backup không được để trống cho backup log.");

            var script = new StringBuilder();
            script.Append($"BACKUP LOG [{options.DatabaseName}] ");
            script.Append($"TO [{options.DeviceName}] ");

            var withOptions = new List<string>();

            if (!string.IsNullOrWhiteSpace(options.BackupName))
            {
                withOptions.Add($"NAME = N'{options.BackupName.Replace("'", "''")}'");
            }
            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                withOptions.Add($"DESCRIPTION = N'{options.Description.Replace("'", "''")}'");
            }

            // --- MODIFIED HERE ---
            // Automatically set INIT for Transaction Log backup
            withOptions.Add("INIT");
            // ---------------------

            //withOptions.Add("COMPRESSION");
            withOptions.Add("STATS = 10");

            if (withOptions.Any())
            {
                script.Append("WITH ");
                script.Append(string.Join(", ", withOptions));
            }
            script.Append(";");
            return script.ToString();
        }
        #endregion

        #region Helper Methods: Backup Execution
        public event Action ExecuteBackupSuccess;
        private void ExecuteBackupScript(string sqlScript, BackupOptions options)
        {
            // --- Prepare UI for long operation ---
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            this.Cursor = Cursors.WaitCursor; // Show wait cursor
            Application.DoEvents(); // Allow UI to update

            try
            {
                // --- Check Database Connection ---
                if (Program.KetNoi() == 0)
                {
                    return;
                }

                // --- Execute the Backup Command ---
                // Assumes Program.ExecuteSqlNonQuery returns 0 for success, non-zero for failure,
                // and handles displaying SQL execution errors internally.
                int executionResult = Program.ExecuteSqlNonQuery(sqlScript);

                if (executionResult == 0) // Success
                {
                    XtraMessageBox.Show($"Backup '{options.BackupName}' cho database '{options.DatabaseName}' trên thiết bị '{options.DeviceName}' hoàn tất thành công!",
                                        "Backup Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // --- Trigger Success Event ---
                    ExecuteBackupSuccess?.Invoke();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) // Catch unexpected exceptions during the execution phase
            {
                XtraMessageBox.Show($"Đã xảy ra lỗi không mong muốn trong quá trình thực hiện backup: {ex.Message}\n\nScript đã thử:\n{sqlScript}",
                                   "Lỗi Thực Thi Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // --- Restore UI state regardless of success or failure ---
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }

}