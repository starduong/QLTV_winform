﻿using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLibrary
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Toàn màn hình
        }

        // Phương thức kiểm tra xem một form có đang mở trong MDI hay không
        private Form CheckExists(Type formType)
        {
            // Duyệt qua tất cả các form con (MDI Children) đang mở
            foreach (Form form in this.MdiChildren)
            {
                // Nếu tìm thấy form có kiểu (Type) trùng với formType, trả về form đó
                if (form.GetType() == formType)
                    return form;
            }
            // Nếu không tìm thấy form nào trùng, trả về null
            return null;
        }

        // Phương thức mở form, đảm bảo không có form trùng lặp trong MDI
        private void OpenForm(Type formType)
        {
            // Kiểm tra xem form có tồn tại hay không bằng cách gọi CheckExists
            Form existingForm = CheckExists(formType);
            if (existingForm != null)
            {
                existingForm.Activate(); // Nếu form đã tồn tại, kích hoạt (đưa nó lên trên cùng)
            }
            else
            {
                // Nếu form chưa mở, tạo một instance mới bằng Activator
                Form form = (Form)Activator.CreateInstance(formType);
                form.MdiParent = this; // Đặt form cha (MDI Parent) là form hiện tại
                form.Show();
            }
        }

        private void btnDauSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FormDauSach));
        }

        private void btnSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnTacGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnTheLoaiSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FormNhanVien));
        }

        private void btnDocGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(FormDocGia));
        }

        // Tùy chỉnh cài đặt của overlay form cho FormMain
        OverlayWindowOptions options = new OverlayWindowOptions(
            backColor: Color.Black,   // Màu nền của overlay là màu đen
            opacity: 0.5,             // Độ trong suốt của overlay là 50%
            fadeIn: false,            // Không có hiệu ứng làm mờ khi xuất hiện
            fadeOut: false            // Không có hiệu ứng làm mờ khi biến mất
        );

        // Hiển thị overlay trên một control cụ thể
        IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions overlayWindowOptions)
        {
            return SplashScreenManager.ShowOverlayForm(control, overlayWindowOptions);
        }

        public void SetInterfaceVisibilityByUserGroup(string userGroup)
        {
            // Các mục hiển thị cho nhân viên
            bool isEmployee = (userGroup == "NHANVIEN");

            // Hiển thị các tab chính theo nhóm người dùng
            rbp_hethong.Visible = rbp_danhmuc.Visible = true;
            rbp_nghiepvu.Visible = rbp_baocao.Visible = isEmployee;

            // Các mục con chỉ dành cho nhân viên
            rpgDangXuat_DoiMatKhau.Visible = rpg_QuanLiTaiKhoan.Visible = rpg_Backup.Visible = rpg_DanhMuc_NguoiDung.Visible = isEmployee;

            this.Refresh();
        }

        // Hàm cập nhật thông tin người dùng trên FormMain
        public void UpdateUserInfo()
        {
            this.sslb_ma.Text = Program.UserName;
            this.sslb_ten.Text = Program.mHoten;
            this.sslb_nhom.Text = Program.mGroup=="DOCGIA"?"ĐỘC GIẢ":"NHÂN VIÊN";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();

            if (Program.mGroup == "DOCGIA")
                Program.KetNoi();

            SetInterfaceVisibilityByUserGroup(Program.mGroup);
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.handle = ShowProgressPanel(this, options);
            FormDangNhap formDangNhap = new FormDangNhap(this);
            // Lắng nghe sự kiện đăng nhập thành công
            formDangNhap.OnLoginSuccess += (userGroup) =>
            {
                // Tạo FormMain mới trước khi đóng FormMain cũ
                FormMain newMain = new FormMain();
                newMain.Show();

                // Cập nhật thông tin trên FormMain mới
                newMain.SetInterfaceVisibilityByUserGroup(userGroup);
                newMain.UpdateUserInfo();

                // Đóng FormMain cũ
                this.Close();

                // Cập nhật tham chiếu CurrentMainForm
                Program.CurrentMainForm = newMain;
            };

            formDangNhap.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.UserName = "";
                Program.mHoten = "";
                Program.mGroup = "DOCGIA";
                Program.LoginName = "DG";
                Program.LoginPassword = "123456";

                FormMain newMain = new FormMain();
                newMain.Show();
                this.Close();
                Program.CurrentMainForm = newMain;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu không còn form nào mở, thoát ứng dụng
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
