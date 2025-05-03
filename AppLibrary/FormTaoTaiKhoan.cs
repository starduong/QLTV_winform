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
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.Import.Html;
using System.Data.SqlClient;

namespace AppLibrary
{
    public partial class FormTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoTaiKhoan()
        {
            InitializeComponent();

        }
        // CÓ THÊM SỰ KIỆN ENTER CHUYỂN Ô TEXT EDIT
        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            this.v_NhanVienChuaCoTaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'qLTVDataSet.v_NhanVienChuaCoTaiKhoan' table. You can move, or remove it, as needed.
            this.v_NhanVienChuaCoTaiKhoanTableAdapter.Fill(this.qLTVDataSet.v_NhanVienChuaCoTaiKhoan);

            // setting gridview ***********************************************
            gvNVChuaCoTK.OptionsDetail.EnableMasterViewMode = false; // Ẩn chế độ xem chi tiết
            gvNVChuaCoTK.OptionsView.ShowGroupPanel = false; // Ẩn bảng nhóm trên header gridview
            gvNVChuaCoTK.OptionsFind.AlwaysVisible = true; // Luôn hiển thị ô tìm kiếm

            // setting UI
            gcBangNhanVien.Visible = false; // Ẩn bảng chọn NHÂN VIÊN
            btnShowPW.Visible = false; // Ẩn nút SHOW mật khẩu
            lblMaNV.Visible = txtMaNV.Visible = false; // Ẩn textEdit MaNV
            txtTenLogin.Enabled = false;
            txtMatKhau.Enabled = false;
            txtConfirmMK.Enabled = false;
            btnHuy.Enabled = btnXacNhan.Enabled = false;

        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            btnChonNhanVien.Visible = false;
            lblMaNV.Visible = txtMaNV.Visible = true;
            txtTenLogin.Enabled = true;
            txtMatKhau.Enabled = true;
            txtConfirmMK.Enabled = true;
            btnHuy.Enabled = btnXacNhan.Enabled = true;

            txtTenLogin.Focus();
            gcBangNhanVien.Visible = true;

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (!checkValidInput()) return;

            // Lấy thông tin nhân viên được chọn từ gridView
            if (gvNVChuaCoTK.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ gridView
            DataRowView selectedRow = (DataRowView)gvNVChuaCoTK.GetFocusedRow();
            string maNV = selectedRow["Mã nhân viên"].ToString();
            string hoTen = selectedRow["Họ tên"].ToString();

            // Chuẩn bị thông tin tài khoản
            string loginName = txtTenLogin.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string username = maNV;
            string role = "NHANVIEN";

            // Tạo câu lệnh SQL để gọi stored procedure
            string sql = $"EXEC sp_TaoTaiKhoan @LGNAME = '{loginName.Replace("'", "''")}', " +
                         $"@PASS = '{password.Replace("'", "''")}', " +
                         $"@USERNAME = '{username.Replace("'", "''")}', " +
                         $"@ROLE = '{role.Replace("'", "''")}'";

            try
            {
                if (Program.KetNoi() == 0) return;
                // Sử dụng hàm ExecuteSqlNonQuery từ Program
                int result = Program.ExecuteSqlNonQuery(sql);

                if (result == 0) // Thành công
                {
                    MessageBox.Show($"Tạo tài khoản thành công cho nhân viên {hoTen}!\n" +
                                  $"Tên đăng nhập: {loginName}\n" +
                                  $"Nhóm quyền: {role}",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset các control
                    txtTenLogin.Clear();
                    txtMatKhau.Clear();
                    txtConfirmMK.Clear();

                    // Load lại danh sách nhân viên
                    this.v_NhanVienChuaCoTaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.v_NhanVienChuaCoTaiKhoanTableAdapter.Fill(this.qLTVDataSet.v_NhanVienChuaCoTaiKhoan);

                    // Nếu tạo thành công, gọi sự kiện
                    AccountEvents.RaiseTaiKhoanDuocTao();
                }
                else // Có lỗi
                {
                    //MessageBox.Show("Lỗi khi tạo tài khoản. Mã lỗi: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
        }

        /****************** Giải pháp an toàn nhất? Dùng parameterized query! ******
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (!checkValidInput()) return;

            // Lấy thông tin nhân viên được chọn từ gridView
            if (gvNVChuaCoTK.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ gridView
            DataRowView selectedRow = (DataRowView)gvNVChuaCoTK.GetFocusedRow();
            string maNV = selectedRow["Mã nhân viên"].ToString();
            string hoTen = selectedRow["Họ tên"].ToString();

            // Chuẩn bị thông tin tài khoản
            string loginName = txtTenLogin.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string username = maNV; // Tạo username theo mã NV
            string role = "NHANVIEN"; // Mặc định role là NHANVIEN

            // Thực hiện tạo tài khoản
            try
            {
                if (Program.KetNoi() == 0) return;
                using (SqlCommand cmd = new SqlCommand("sp_TaoTaiKhoan", Program.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@LGNAME", loginName);
                    cmd.Parameters.AddWithValue("@PASS", password);
                    cmd.Parameters.AddWithValue("@USERNAME", username);
                    cmd.Parameters.AddWithValue("@ROLE", role);

                    // Thêm tham số output cho thông báo lỗi
                    SqlParameter errorMsgParam = new SqlParameter("@ERROR_MSG", SqlDbType.NVarChar, 4000);
                    errorMsgParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMsgParam);

                    // Thêm tham số return
                    SqlParameter returnParam = cmd.Parameters.Add("RETURN_VALUE", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;

                    // Thực thi stored procedure
                    cmd.ExecuteNonQuery();

                    // Kiểm tra kết quả trả về
                    int result = (int)returnParam.Value;
                    string errorMsg = errorMsgParam.Value?.ToString();

                    if (result == 0) // Thành công
                    {
                        MessageBox.Show($"Tạo tài khoản thành công cho nhân viên {hoTen}!\n" +
                                      $"Tên đăng nhập: {loginName}\n" +
                                      $"Username: {username}",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTenLogin.Clear();
                        txtMaNV.Clear();
                        txtMaNV.Clear();

                        this.v_NhanVienChuaCoTaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        // Load lại danh sách nhân viên chưa có tài khoản
                        this.v_NhanVienChuaCoTaiKhoanTableAdapter.Fill(this.qLTVDataSet.v_NhanVienChuaCoTaiKhoan);
                    }
                    else // Có lỗi
                    {
                        MessageBox.Show($"Lỗi khi tạo tài khoản: {errorMsg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
            }
        }
        */
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenLogin.Text = ""; txtTenLogin.Enabled = false;
            txtMatKhau.Text = ""; txtMatKhau.Enabled = false;
            txtConfirmMK.Text = ""; txtConfirmMK.Enabled = false;
            btnHuy.Enabled = btnXacNhan.Enabled = false;
            gcBangNhanVien.Visible = false;
            btnChonNhanVien.Visible = true;
            lblMaNV.Visible = txtMaNV.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPW_Click(object sender, EventArgs e)
        {
            txtMatKhau.Properties.UseSystemPasswordChar = true;
            btnHidePW.Visible = true;
            btnShowPW.Visible = false;
        }

        private void btnHidePW_Click(object sender, EventArgs e)
        {
            txtMatKhau.Properties.UseSystemPasswordChar = false;
            btnHidePW.Visible = false;
            btnShowPW.Visible = true;
        }

        // Kiểm tra dữ liệu nhập vào
        private bool checkValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenLogin.Text.Trim()))
            {
                MessageBox.Show("Tên login không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLogin.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTenLogin.Text.Trim()) ||
                             txtTenLogin.Text.Length > 128 ||
                             txtTenLogin.Text.Contains("\\"))
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ. Không được rỗng, không quá 128 ký tự và không chứa ký tự \\.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLogin.Focus();
                return false;
            }

            // THÊM TRƯỜNG HỢP TÊN LOGIN ĐÃ TỒN TẠI TRONG SYS.SYSLOGINS ***
            //else if (KiemTraLoginDaTonTai(txtTenLogin.Text.Trim()))
            //{
            //    MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTenLogin.Focus();
            //    return false;
            //}

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }
            else if (txtMatKhau.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmMK.Text.Trim()))
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmMK.Focus();
                return false;
            }
            else if (txtMatKhau.Text != txtConfirmMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmMK.Focus();
                return false;
            }
            return true;
        }

        /*
        private bool KiemTraLoginDaTonTai(string loginName)
        {
            // Chuỗi truy vấn SQL để kiểm tra login đã tồn tại chưa
            string query = $"SELECT SUSER_SID('{loginName.Replace("'", "''")}')";

            // Đóng reader cũ nếu đang mở
            if (Program.myReader != null && !Program.myReader.IsClosed)
            {
                Program.myReader.Close();
            }

            // Sử dụng ExecuteSqlDataReader để thực hiện câu lệnh SQL
            Program.myReader = Program.ExecuteSqlDataReader(query);

            if (Program.myReader == null) return false;
            Program.myReader.Close(); // Đóng lại reader sau khi dùng xong

            return true; // Nếu login đã tồn tại trả về TRUE
        }
        */

    }
}