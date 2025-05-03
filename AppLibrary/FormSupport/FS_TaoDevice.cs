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
using DevExpress.XtraSplashScreen;
using AppLibrary.ClassSupport;
using System.Data.SqlClient;
using System.IO;

namespace AppLibrary.FormSupport
{
    public partial class FS_TaoDevice : DevExpress.XtraEditors.XtraForm
    {
        private string _databaseName;
        public FS_TaoDevice(string databaseName)
        {
            InitializeComponent();
            _databaseName = databaseName;
        }
        private void FS_TaoDevice_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_databaseName))
            {
                txtDeviceName.Text = $"DEVICE_{_databaseName}";
            }
            else
            {
                MessageBox.Show("Không có tên cơ sở dữ liệu nào được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string deviceName = txtDeviceName.Text.Trim();
                string filePath = btnFilePath.Text.Trim();

                if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(filePath))
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ tên device và đường dẫn file.",
                                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (IsBackupDeviceExists(deviceName))
                {
                    XtraMessageBox.Show($"Device '{deviceName}' đã tồn tại trong hệ thống.",
                              "Device đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidBackupPath(filePath))
                {
                    XtraMessageBox.Show("Đường dẫn file backup không hợp lệ hoặc không tồn tại thư mục.",
                                        "Lỗi đường dẫn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo câu lệnh SQL để thêm thiết bị backup
                string sql = $"EXEC sp_addumpdevice 'disk', '{deviceName}', '{filePath}'";

                // Thực thi câu lệnh SQL
                if (Program.KetNoi() == 0) return; // Nếu không kết nối được thì thoát

                if (Program.ExecuteSqlNonQuery(sql) == 0)
                {
                    XtraMessageBox.Show($"Tạo device thành công!\nTên: {deviceName}\nĐường dẫn: {filePath}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Nếu có lỗi xảy ra trong quá trình thực thi câu lệnh SQL
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi không xác định:\n" + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsBackupDeviceExists(string deviceName)
        {
            const string sql = "SELECT COUNT(*) FROM sys.backup_devices WHERE name = @deviceName";
            if (Program.KetNoi() == 0) return false;
            using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@deviceName", deviceName);
                try
                {
                    if (Program.conn.State == ConnectionState.Closed)
                        Program.conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            return count > 0;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show("Lỗi khi kiểm tra thiết bị backup: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        bool IsValidBackupPath(string path)
        {
            try
            {
                // 1. Kiểm tra path không rỗng
                if (string.IsNullOrWhiteSpace(path))
                    return false;

                // 2. Kiểm tra path không chứa ký tự không hợp lệ
                if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                    return false;

                // 3. Kiểm tra có đúng định dạng file .bak
                if (!path.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    return false;

                // 4. Kiểm tra định dạng ổ đĩa (VD: C:\ hoặc D:\)
                string root = Path.GetPathRoot(path);
                if (string.IsNullOrEmpty(root) || !Directory.Exists(root))
                    return false;

                // 5. Kiểm tra thư mục cha có tồn tại
                string directory = Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
                    return false;

                // 6. Regex kiểm tra pattern đầy đủ (optional, kiểm soát thêm)
                // VD: @"^[A-Za-z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]+\.bak$"
                // Có thể bỏ qua nếu dùng các bước trên

                return true;
            }
            catch
            {
                return false;
            }
        }


        private void FS_TaoDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt overlay form đang mở -> hiện form chính
            if (Program.handle != null) OverlayHelper.CloseOverlay(Program.handle);
        }

        private void btnFilePath_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Chọn file backup (*.bak)";
                    openFileDialog.Filter = "Backup Files (*.bak)|*.bak|Tất cả các file (*.*)|*.*";
                    openFileDialog.CheckFileExists = false; // Cho phép người dùng nhập tay tên file chưa tồn tại

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        btnFilePath.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi chọn file:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}