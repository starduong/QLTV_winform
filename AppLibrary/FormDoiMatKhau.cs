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

namespace AppLibrary
{
	public partial class FormDoiMatKhau: DevExpress.XtraEditors.XtraForm
	{
        public FormDoiMatKhau()
		{
            InitializeComponent();
		}

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.v_NhanVienCoTaiKhoanTableAdapter.Connection.ConnectionString =Program.connstr;
            // TODO: This line of code loads data into the 'qLTVDataSet.v_NhanVienCoTaiKhoan' table. You can move, or remove it, as needed.
            this.v_NhanVienCoTaiKhoanTableAdapter.Fill(this.qLTVDataSet.v_NhanVienCoTaiKhoan);

            // Đăng ký lắng sự kiện tạo tài khoản
            AccountEvents.TaiKhoanDuocTao += AccountEvents_TaiKhoanDuocTao;

            // setting gridview ***********************************************
            gvNVCoTK.OptionsDetail.EnableMasterViewMode = false; // Ẩn chế độ xem chi tiết
            gvNVCoTK.OptionsView.ShowGroupPanel = false; // Ẩn bảng nhóm trên header gridview
            gvNVCoTK.OptionsFind.AlwaysVisible = true; // Luôn hiển thị ô tìm kiếm

            btnShowPW.Visible = false; // Ẩn nút SHOW mật khẩu
        }

        private void AccountEvents_TaiKhoanDuocTao(object sender, EventArgs e)
        {
            // Refresh lại gridview
            this.v_NhanVienCoTaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'qLTVDataSet.v_NhanVienCoTaiKhoan' table. You can move, or remove it, as needed.
            this.v_NhanVienCoTaiKhoanTableAdapter.Fill(this.qLTVDataSet.v_NhanVienCoTaiKhoan);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!checkValidInput()) return; // Kiểm tra đầu vào

            // Lấy tên login từ GridView
            DataRowView row = (DataRowView)gvNVCoTK.GetRow(gvNVCoTK.FocusedRowHandle);
            if (row == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên cần đổi mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string loginName = txtTenLogin.Text.Trim();
            string newPassword = txtMatKhau.Text.Trim();

            // TRUYỀN CÁC THAM SỐ VÀ GỌI SP ĐỔI MẬT KHẨU
            // Tạo câu lệnh SQL để gọi stored procedure
            string sql = $"EXEC sp_DoiMatKhau @LGNAME = '{loginName.Replace("'", "''")}', " +
                         $"@MKMOI = '{newPassword.Replace("'", "''")}'";

            try
            {
                if (Program.KetNoi() == 0) return;

                int result = Program.ExecuteSqlNonQuery(sql);

                if (result == 0)
                {
                    MessageBox.Show($"Đổi mật khẩu thành công cho tài khoản [{loginName}].",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Trường hợp lỗi nhưng đã được thông báo trong ExecuteSqlNonQuery
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.conn.Close();
                gvNVCoTK.RefreshData();
                txtMatKhau.Clear();
                txtConfirmMK.Clear();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            gvNVCoTK.RefreshData();
            gvNVCoTK.FocusedRowHandle = 0;
            txtMatKhau.Clear();
            txtConfirmMK.Clear();
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

        private bool checkValidInput()
        {
            if (gvNVCoTK.GetFocusedRow() == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên cần đổi mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


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
    }
}