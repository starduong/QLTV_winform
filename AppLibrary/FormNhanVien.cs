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
using System.Data.SqlClient;
using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;

namespace AppLibrary
{
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private bool isAdding = false;

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.tam_NhanVien.Connection.ConnectionString = Program.connstr;
            this.ta_NhanVien.Fill(this.ds_QLTV.NHANVIEN);
            nHANVIENGridControl.DataSource = bds_NhanVien;
            // Khóa chỉnh sửa trên gridView1
            gridView1.OptionsBehavior.Editable = false;
            btnHuyThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // Gán sự kiện FocusedRowChanged cho gridView1
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            colMANV.OptionsColumn.AllowEdit = false;
            colMANV.OptionsColumn.ReadOnly = true;
            textEditMANV.ReadOnly = true;
        }
        private int LayManvLonNhat()
        {
            int maxManv = 0;
            string sql = "SELECT ISNULL(MAX(MANV), 0) FROM NHANVIEN";
            using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                object result = cmd.ExecuteScalar();
                maxManv = Convert.ToInt32(result);
            }
            return maxManv;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            isAdding = false;
            if (bds_NhanVien.Current != null)
            {
                DataRowView row = (DataRowView)bds_NhanVien.Current;
                textEditMANV.Text = row["MANV"].ToString();
                textEditHO.Text = row["HONV"].ToString();
                textEditTEN.Text = row["TENNV"].ToString();
                textEditDIACHI.Text = row["DIACHI"].ToString();
                textEditDIENTHOAI.Text = row["DIENTHOAI"].ToString();
                textEditEMAIL.Text = row["EMAIL"].ToString();
                // Hiển thị giới tính lên RadioButton
                if (row["GIOITINH"] != DBNull.Value)
                {
                    bool gioiTinh = Convert.ToBoolean(row["GIOITINH"]);
                    radioButtonNAM.Checked = gioiTinh;
                    radioButtonNU.Checked = !gioiTinh;
                }
                else
                {
                    radioButtonNAM.Checked = false;
                    radioButtonNU.Checked = false;
                }

                btnGhi.Enabled = true;
            }
            else
            {
                // Xóa các điều khiển khi không có dòng nào được chọn
                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";  
                radioButtonNAM.Checked = false;
                radioButtonNU.Checked = false;
            }
        }
       

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Thêm bản ghi mới vào BindingSource
            bds_NhanVien.AddNew();

            int nextManv = LayManvLonNhat() + 1;

            // Cập nhật lại MANV cho dòng mới (dù không lưu vào DB – để hiển thị trên GridControl)
            DataRowView newRow = (DataRowView)bds_NhanVien.Current;
            newRow["MANV"] = nextManv;
            textEditMANV.Text = nextManv.ToString();
            textEditHO.Text = "";
            textEditTEN.Text = "";
            textEditDIACHI.Text = "";
            textEditDIENTHOAI.Text = "";
            textEditEMAIL.Text = "";
            radioButtonNAM.Checked = false;
            radioButtonNU.Checked = false;

            // 5. Vô hiệu hóa các nút không cần thiết
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnRefresh.Enabled = false;
            btnGhi.Enabled = true;
            btnPhucHoi.Enabled = false;
            btnHuyThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 6. Tập trung vào TextEdit để người dùng nhập dữ liệu
            textEditHO.Focus();
            isAdding = true;
        }
        // Kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra định dạng số điện thoại (10 chữ số, bắt đầu bằng số 0)
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textEditHO.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (
                    string.IsNullOrWhiteSpace(textEditTEN.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên v!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (
                    string.IsNullOrWhiteSpace(textEditDIACHI.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Địa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!radioButtonNAM.Checked && !radioButtonNU.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textEditEMAIL.Text) && !IsValidEmail(textEditEMAIL.Text))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textEditDIENTHOAI.Text) && !IsValidPhoneNumber(textEditDIENTHOAI.Text))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRowView currentRow = (DataRowView)bds_NhanVien.Current;
                currentRow["HONV"] = textEditHO.Text;
                currentRow["TENNV"] = textEditTEN.Text;
                currentRow["GIOITINH"] = radioButtonNAM.Checked ? 1 : 0;
                currentRow["DIACHI"] = textEditDIACHI.Text;
                currentRow["EMAIL"] = textEditEMAIL.Text;
                currentRow["DIENTHOAI"] = textEditDIENTHOAI.Text;

                bds_NhanVien.EndEdit();
                ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                MessageBox.Show(isAdding ? "Đã thêm nhân viên mới!" : "Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnRefresh.Enabled = true;
                btnGhi.Enabled = false;
                btnHuyThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                isAdding = false; // Reset lại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nHANVIENGridControl_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Reload dữ liệu từ cơ sở dữ liệu
                ds_QLTV.NHANVIEN.Clear();
                ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                // Xóa các điều khiển
                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                radioButtonNAM.Checked = false;
                radioButtonNU.Checked = false;

                // Chọn lại dòng đầu tiên (nếu có)
                if (bds_NhanVien.Count > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                }

                MessageBox.Show("Dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_NhanVien.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa dòng hiện tại trong BindingSource
                    bds_NhanVien.RemoveCurrent();

                    // Lưu thay đổi vào cơ sở dữ liệu
                    ta_NhanVien.Update(ds_QLTV.NHANVIEN);

                    // Reload dữ liệu vào gridView1
                    ds_QLTV.NHANVIEN.Clear();
                    ta_NhanVien.Fill(ds_QLTV.NHANVIEN);

                    // Xóa các điều khiển
                    textEditMANV.Text = "";
                    textEditHO.Text = "";
                    textEditTEN.Text = "";
                    textEditDIACHI.Text = "";
                    textEditDIENTHOAI.Text = "";
                    textEditEMAIL.Text = "";
                    radioButtonNAM.Checked = false;
                    radioButtonNU.Checked = false;

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnHuyThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 1. Hủy thao tác thêm
            bds_NhanVien.CancelEdit();

                textEditMANV.Text = "";
                textEditHO.Text = "";
                textEditTEN.Text = "";
                textEditDIACHI.Text = "";
                textEditDIENTHOAI.Text = "";
                textEditEMAIL.Text = "";
                radioButtonNAM.Checked = false;
                radioButtonNU.Checked = false;
            
            // 3. Bật lại các nút và ẩn nút Hủy Thêm
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnRefresh.Enabled = true;
            btnGhi.Enabled = true;
            btnHuyThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            // 4. Bật lại TextEdit mã nhân viên
            textEditMANV.ReadOnly = true;
        }


    }
}