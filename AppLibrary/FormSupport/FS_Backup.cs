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
using AppLibrary.ClassSupport;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

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
            public bool IsInit { get; set; }
        }
        #endregion

        private readonly string _databaseName;

        #region Constructor
        public FS_Backup(string databaseName)
        {
            InitializeComponent();
            this._databaseName = databaseName;

            if (string.IsNullOrWhiteSpace(this._databaseName))
            {
                XtraMessageBox.Show("Không có tên cơ sở dữ liệu nào được cung cấp.", "Lỗi Khởi Tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers: Form Load / Closing
        private void FS_Backup_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_databaseName))
            {
                BeginInvoke(new Action(Close));
                return;
            }

            txtDBName.Text = _databaseName;
            btnOk.Enabled = true;
            cbBackupType.SelectedIndex = 0;

            try
            {
                // Load danh sách thiết bị backup
                sYSBACKUP_DEVICETableAdapter.Connection.ConnectionString = Program.connstr;
                sYSBACKUP_DEVICETableAdapter.Fill(qLTVDataSet.SYSBACKUP_DEVICE);

                if (cbDeviceName.Items.Count == 0)
                {
                    XtraMessageBox.Show(
                        "Không tìm thấy thiết bị backup nào được cấu hình trong hệ thống (SYSBACKUP_DEVICE).\nVui lòng tạo thiết bị backup trước.",
                        "Thiếu Thiết Bị Backup",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    btnOk.Enabled = false;
                }
                else
                {
                    cbDeviceName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Lỗi khi tải thiết bị backup: {ex.Message}\nVui lòng kiểm tra kết nối hoặc liên hệ quản trị viên.",
                    "Lỗi Hệ Thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnOk.Enabled = false;
            }

            try
            {
                // Kiểm tra lịch sử backup
                sp_DanhSachBackupTableAdapter.Connection.ConnectionString = Program.connstr;
                sp_DanhSachBackupTableAdapter.Fill(qLTVDataSet.sp_DanhSachBackup, _databaseName);
            }
            catch { }

            // Cập nhật giao diện
            UpdateDefaultBackupName();
            UpdateInitNoInitOptions();
            UpdateBackupTypeNoFullBK();
        }


        private void FS_Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            UpdateInitNoInitOptions();
        }

        private void UpdateDefaultBackupName()
        {
            string backupType = cbBackupType.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(_databaseName) && !string.IsNullOrEmpty(backupType))
            {
                txtNameBK.Text = $"{_databaseName}-{backupType} Database Backup";
            }
        }

        private void UpdateBackupTypeNoFullBK()
        {
            cbBackupType.Enabled = IsFullBackupExists(_databaseName);
        }

        private void UpdateInitNoInitOptions()
        {
            string selectedBackupType = cbBackupType.SelectedItem?.ToString() ?? string.Empty;
            switch (selectedBackupType)
            {
                case "Differential":
                    rbtINIT.Enabled = false;
                    rbtNOINIT.Checked = true;
                    break;
                case "Full":
                case "Transaction Log":
                    rbtINIT.Enabled = true;
                    rbtNOINIT.Checked = true;
                    break;
                default:
                    rbtNOINIT.Checked = false;
                    break;
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
            if (!ValidateInputs()) { return; }

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

            // Confirmation for INIT is implicit by user selecting rbtINIT.
            if (options.IsInit)
            {
                var confirmResult = XtraMessageBox.Show(
                    $"Bạn đã chọn tùy chọn 'INIT'.\n" +
                    $"Thao tác này sẽ XÓA TẤT CẢ các bản sao lưu hiện có trên thiết bị '{options.DeviceName}' và bắt đầu một bộ sao lưu mới.\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    $"Xác Nhận Ghi Đè (INIT)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }

            string sqlScript;
            try
            {
                sqlScript = options.IsTransactionLog
                    ? GenerateLogBackupScript(options)
                    : GenerateDataBackupScript(options);
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

            ExecuteBackupScript(sqlScript, options);
        }
        #endregion

        #region Helper Methods: Input Validation, Option Building, Prerequisite Checks
        private bool ValidateInputs()
        {
            if (cbDeviceName.SelectedItem == null || cbDeviceName.SelectedValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn một thiết bị backup từ danh sách.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbDeviceName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNameBK.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên cho bản backup.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameBK.Focus();
                return false;
            }
            if (cbBackupType.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn loại backup (Full, Differential, Transaction Log).", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbBackupType.Focus();
                return false;
            }
            if (!this.rbtINIT.Checked && !this.rbtNOINIT.Checked)
            {
                XtraMessageBox.Show("Vui lòng chọn tùy chọn INIT hoặc NOINIT.", "Thiếu Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.rbtINIT.CanFocus) this.rbtINIT.Focus();
                return false;
            }
            return true;
        }

        private BackupOptions BuildBackupOptions()
        {
            string backupType = cbBackupType.SelectedItem?.ToString();
            object selectedDeviceValue = cbDeviceName.SelectedValue;

            if (string.IsNullOrEmpty(backupType))
                throw new InvalidOperationException("Loại backup chưa được chọn.");
            if (selectedDeviceValue == null)
                throw new InvalidOperationException("Thiết bị backup chưa được chọn.");

            var options = new BackupOptions
            {
                DatabaseName = this._databaseName,
                BackupName = txtNameBK.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DeviceName = selectedDeviceValue.ToString(),
                IsDifferential = (backupType == "Differential"),
                IsTransactionLog = (backupType == "Transaction Log"),
                IsInit = this.rbtINIT.Checked
            };
            return options;
        }

        private bool IsFullBackupExists(string databaseName)
        {
            // Kiểm tra xem có bản full backup (type='D') nào trong bdsDSBACKUP hay không
            bool hasFullBackup = false;
            foreach (DataRowView row in sp_DanhSachBackupBindingSource)
            {
                string backupType = row["type"]?.ToString();
                if (backupType == "D")
                {
                    hasFullBackup = true;
                    break;
                }
            }
            return hasFullBackup;
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

            withOptions.Add(options.IsInit ? "INIT" : "NOINIT");
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

            withOptions.Add(options.IsInit ? "INIT" : "NOINIT");
            withOptions.Add("NO_TRUNCATE");
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
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                if (Program.KetNoi() == 0) return;

                int executionResult = Program.ExecuteSqlNonQuery(sqlScript);

                if (executionResult == 0)
                {
                    XtraMessageBox.Show($"Backup '{options.BackupName}' cho database '{options.DatabaseName}' trên thiết bị '{options.DeviceName}' (sử dụng {(options.IsInit ? "INIT" : "NOINIT")}) hoàn tất thành công!",
                                        "Backup Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExecuteBackupSuccess?.Invoke();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Đã xảy ra lỗi không mong muốn trong quá trình thực hiện backup: {ex.Message}\n\nScript đã thử:\n{sqlScript}",
                                   "Lỗi Thực Thi Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnOk.Enabled = true;
                btnCancel.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}