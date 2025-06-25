using System;
using System.Data;
using System.Windows.Forms;
using AppLibrary.ClassSupport;
using DevExpress.CodeParser;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraSplashScreen;

namespace AppLibrary
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private FormMain mainForm; // Tham chiếu đến FormMain
        public FormDangNhap(FormMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            //Default Bật icon xem mật khẩu và ẩn đi icon ẩn mật khẩu
            icon_showpw.Visible = true;
            icon_hidepw.Visible = false;
            this.ActiveControl = txt_tendangnhap; // Đặt txt_tendangnhap làm control active
        }
        private void icon_showpw_Click(object sender, EventArgs e)
        {
            // Hiện mật khẩu: Bỏ ký tự ẩn (PasswordChar)
            //txt_matkhau.Properties.PasswordChar = '\0'; // '\0' nghĩa là không dùng ký tự ẩn
            txt_matkhau.Properties.UseSystemPasswordChar = false; // Tắt chế độ mật khẩu hệ thống
            // (Tùy chọn) Ẩn icon_showpw và hiện icon_hidepw
            icon_showpw.Visible = false;
            icon_hidepw.Visible = true;
        }

        private void icon_hidepw_Click(object sender, EventArgs e)
        {
            // Ẩn mật khẩu: Đặt ký tự ẩn (ví dụ: '*')
            //txt_matkhau.Properties.PasswordChar = '*'; // Dùng ký tự '*' để ẩn
            txt_matkhau.Properties.UseSystemPasswordChar = true; // Bật chế độ mật khẩu hệ thống
            // (Tùy chọn) Ẩn icon_hidepw và hiện icon_showpw
            icon_hidepw.Visible = false;
            icon_showpw.Visible = true;
        }

        private void icon_showpw_MouseHover(object sender, EventArgs e) => this.Cursor = Cursors.Hand;
        private void icon_showpw_MouseLeave(object sender, EventArgs e) => this.Cursor = Cursors.Default;
        private void icon_hidepw_MouseHover(object sender, EventArgs e) => this.Cursor = Cursors.Hand;
        private void icon_hidepw_MouseLeave(object sender, EventArgs e) => this.Cursor = Cursors.Default;
        private void img_dangnhap_Click(object sender, EventArgs e) => txt_tendangnhap.Focus();
        private void img_matkhau_Click(object sender, EventArgs e) => txt_matkhau.Focus();

        private void txt_tendangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) // Kiểm tra phím Down hoặc Enter
            {
                if (txt_tendangnhap.Text.Trim() == "") // Kiểm tra nếu txt_tendangnhap rỗng
                {
                    MessageBox.Show("Tên đăng nhập không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_tendangnhap.Focus(); // Giữ focus ở txt_tendangnhap
                    e.Handled = true; // Ngăn hành vi mặc định của phím
                }
                else
                {
                    txt_matkhau.Focus(); // Chuyển focus sang txt_matkhau nếu không rỗng
                    e.Handled = true; // Ngăn hành vi mặc định của phím
                }
            }
        }

        private void txt_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) // Kiểm tra nếu phím mũi tên lên được nhấn
            {
                txt_tendangnhap.Focus(); // Chuyển con trỏ lên txt_tendangnhap
                e.Handled = true;        // Ngăn hành vi mặc định của phím (tùy chọn)
            }

            if (e.KeyCode == Keys.Enter)
            {
                btn_dangnhap.PerformClick(); // Gọi sự kiện click của nút đăng nhập
                e.Handled = true;
            }
        }

        private void btn_dangnhap_MouseHover(object sender, EventArgs e) => this.Cursor = Cursors.Hand;
        private void btn_dangnhap_MouseLeave(object sender, EventArgs e) => this.Cursor = Cursors.Default;
        private void btn_thoat_MouseHover(object sender, EventArgs e) => this.Cursor = Cursors.Hand;
        private void btn_thoat_MouseLeave(object sender, EventArgs e) => this.Cursor = Cursors.Default;

        /********************************************************************************
         * Xử lí đăng nhập
         ********************************************************************************/

        // Tạo sự kiện đăng nhập thành công
        public event Action<string> OnLoginSuccess;
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            /* Kiểm tra tên đăng nhập và mật khẩu */
            if (txt_tendangnhap.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tendangnhap.Focus();
                return;
            }

            if (txt_matkhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_matkhau.Focus();
                return;
            }
            /* Lấy input tên đăng nhập và mật khẩu */
            Program.LoginName = txt_tendangnhap.Text.Trim();
            Program.LoginPassword = txt_matkhau.Text.Trim();
            /* Kiểm tra kết nối */
            if (Program.KetNoi() == 0)
                return;

            String statement = "EXEC SP_DANGNHAP '" + Program.LoginName + "'";
            Program.myReader = Program.ExecuteSqlDataReader(statement);
            if (Program.myReader == null)
                return;
            // đọc một dòng của myReader
            Program.myReader.Read();

            Program.UserName = Program.myReader.GetString(0);// lấy userName
            if (Convert.IsDBNull(Program.UserName))
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập \n Hãy thử tài khoản khác", "Thông Báo", MessageBoxButtons.OK);
            }

            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);

            Program.myReader.Close();

            // Gọi thủ tục cập nhật trạng thái độc giả quá hạn
            string updateStatus = "EXEC sp_CapNhatHoatDongDocGia";
            Program.ExecuteSqlNonQuery(updateStatus);
            if (Program.conn.State == ConnectionState.Open)
                Program.conn.Close();

            // Kích hoạt sự kiện đăng nhập thành công
            OnLoginSuccess?.Invoke(Program.mGroup);

            // **Đóng Form đăng nhập**
            this.Close();

        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Đây là thời điểm form đã bị đóng hoàn toàn rồi.
            //Bạn không thể ngăn việc đóng form ở đây.
        }
        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Đây là thời điểm bạn còn có thể ngăn không cho form bị đóng.
            //Dùng để hiển thị thông báo xác nhận, kiểm tra dữ liệu chưa lưu, hoặc hủy việc đóng form nếu cần.
            //Tắt overlay form đang mở -> hiện form chính
            if (Program.handle != null)
            {
                OverlayHelper.CloseOverlay(Program.handle);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            //Đóng form đăng nhập
            this.Close();
        }

        private void txt_tendangnhap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lb_tendangnhap_Click(object sender, EventArgs e)
        {

        }

        private void pn_matkhau_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_matkhau_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}