using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLibrary
{
    public partial class FormTraSach : Form
    {
        public FormTraSach()
        {
            InitializeComponent();
            LoadPhieuMuon();
        }
        private int tinhHuongTraSach = 0; // 1 = Tốt, 2 = Hỏng, 3 = Mất

        private void LoadPhieuMuon()
        {
            if (Program.KetNoi() == 0) return; // Đảm bảo kết nối CSDL

            string sql = "EXEC sp_GetPhieuMuonChiTiet"; // Gọi SP đã tạo

            DataTable dt = Program.ExecuteSqlDataTable(sql); // Lấy dữ liệu
            gridControl1.DataSource = dt;

            // Tạo nút "Trả sách" nếu chưa có
            if (!gridView1.Columns.Contains(gridView1.Columns["Trả sách"]))
            {
                var btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
                {
                    TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                };
                btn.Buttons[0].Caption = "Trả sách";
                btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btn.ButtonClick += Btn_ButtonClick;

                gridControl1.RepositoryItems.Add(btn);

                var col = gridView1.Columns.AddVisible("Trả sách");
                col.ColumnEdit = btn;
                col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                col.Width = 80;
            }

            gridView1.BestFitColumns(); // Tự động chỉnh kích thước cột
            gridView1.Columns["MAPHIEU"].Caption = "Mã phiếu";
            gridView1.Columns["HotenDocGia"].Caption = "Họ tên độc giả chưa trả sách";
            gridView1.Columns["Sach"].Caption = "Sách đã mượn";
            gridView1.Columns["Ngaymuon"].Caption = "Ngày mượn";
            gridView1.Columns["Ngaymuon"].Caption = "Ngày mượn";
            gridView1.Columns["HinhThuc"].Caption = "Hình thức";
            gridView1.Columns["TrangThai"].Caption = "Trạng thái";
            gridView1.OptionsBehavior.ReadOnly = true;
            panelControl1.Visible = false;
        }
        private void Btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedDataRow();
            if (selectedRow != null)
            {
                // Lưu thông tin vào PanelControl
                string maphieu = selectedRow["Maphieu"].ToString();
                string masach = selectedRow["Sach"].ToString().Split('-')[0].Trim();

                textEditMPS.Text = maphieu;
                textEditSACH.Text = masach;
                textEditNVNS.Text = Program.mHoten;
                panelControl1.Visible = true;
                textEditMPS.ReadOnly = true;
                textEditNVNS.ReadOnly = true;
                textEditSACH.ReadOnly = true;
            }
        }


        private void radioButtonTot_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTot.Checked)
            {
                tinhHuongTraSach = 1;
                radioButtonHong.Checked = false;
                radioButtonMat.Checked = false;
            }
        }

        private void radioButtonHong_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHong.Checked)
            {
                tinhHuongTraSach = 2;
                radioButtonTot.Checked = false;
                radioButtonMat.Checked = false;
            }
        }

        private void radioButtonMat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMat.Checked)
            {
                tinhHuongTraSach = 3;
                radioButtonTot.Checked = false;
                radioButtonHong.Checked = false;
            }
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadPhieuMuon();
            textEditMPS.Text = "";
            textEditSACH.Text = "";
            textEditNVNS.Text = "";
            radioButtonTot.Checked = false;
            radioButtonHong.Checked = false;
            radioButtonMat.Checked = false;
            panelControl1.Visible = false;
        }
        private bool isTaiCho = false;

        // Thêm sự kiện click cho barButtonItemTAICHO
        private void barButtonItemTAICHO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isTaiCho = true;
            LoadPhieuMuonTaiCho();
            textEditMPS.Text = "";
            textEditSACH.Text = "";
            textEditNVNS.Text = "";
            radioButtonTot.Checked = false;
            radioButtonHong.Checked = false;
            radioButtonMat.Checked = false;
            panelControl1.Visible = false;
        }
        private void LoadPhieuMuonTaiCho()
        {
            if (Program.KetNoi() == 0) return;

            string sql = "EXEC sp_GetPhieuMuonChiTietTaiCho";
            DataTable dt = Program.ExecuteSqlDataTable(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phiếu mượn tại chỗ.");
                gridControl1.DataSource = null;
                return;
            }

            gridControl1.DataSource = dt;

            // Gắn lại repository cho nút Trả sách
            if (!gridView1.Columns.Contains(gridView1.Columns["Trả sách"]))
            {
                var btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
                {
                    TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                };
                btn.Buttons[0].Caption = "Trả sách";
                btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btn.ButtonClick += Btn_ButtonClick;

                gridControl1.RepositoryItems.Add(btn);

                var col = gridView1.Columns.AddVisible("Trả sách");
                col.ColumnEdit = btn;
                col.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                col.Width = 80;
            }

            // Ánh xạ tên cột và đặt Caption rõ ràng
            if (gridView1.Columns["MAPHIEU"] != null)
                gridView1.Columns["MAPHIEU"].Caption = "Mã phiếu";

            if (gridView1.Columns["HotenDocGia"] != null)
                gridView1.Columns["HotenDocGia"].Caption = "Họ tên độc giả";

            if (gridView1.Columns["Sach"] != null)
                gridView1.Columns["Sach"].Caption = "Tên sách";

            if (gridView1.Columns["Ngaymuon"] != null)
            {
                gridView1.Columns["Ngaymuon"].Caption = "Ngày mượn";
                gridView1.Columns["Ngaymuon"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["Ngaymuon"].DisplayFormat.FormatString = "dd/MM/yyyy";
            }

            if (gridView1.Columns["HinhThuc"] != null)
                gridView1.Columns["HinhThuc"].Caption = "Hình thức";

            if (gridView1.Columns["TrangThai"] != null)
                gridView1.Columns["TrangThai"].Caption = "Trạng thái";

            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.ReadOnly = true;
            panelControl1.Visible = false;
        }


        // Sửa lại sự kiện simpleButtonTS_Click để xử lý trường hợp mượn tại chỗ
        private void simpleButtonTS_Click(object sender, EventArgs e)
        {
            // Lấy mã phiếu mượn và mã sách
            if (!long.TryParse(textEditMPS.Text, out long maphieu))
            {
                MessageBox.Show("Mã phiếu mượn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string masach = textEditSACH.Text;
            if (string.IsNullOrEmpty(masach))
            {
                MessageBox.Show("Không tìm thấy mã sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã nhân viên từ biến toàn cục Program
            if (!int.TryParse(Program.UserName, out int manvns))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ (phải là kiểu số).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (Program.KetNoi() == 0) return;

                SqlCommand cmd = new SqlCommand
                {
                    Connection = Program.conn
                };

                // Kiểm tra nếu là mượn tại chỗ và quá hạn 2 ngày
                if (isTaiCho)
                {
                    string checkDateSql = "SELECT DATEDIFF(day, Ngaymuon, GETDATE()) FROM PHIEUMUON WHERE Maphieu = @Maphieu";
                    SqlCommand checkDateCmd = new SqlCommand(checkDateSql, Program.conn);
                    checkDateCmd.Parameters.AddWithValue("@Maphieu", maphieu);
                    int daysDiff = Convert.ToInt32(checkDateCmd.ExecuteScalar());

                    if (daysDiff > 2)
                    {
                        MessageBox.Show("Sách mượn tại chỗ đã quá hạn 2 ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (tinhHuongTraSach == 1) // Sách tốt
                {
                    cmd.CommandText = "sp_TraSachTot";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Maphieu", maphieu);
                    cmd.Parameters.AddWithValue("@Masach", masach);
                    cmd.Parameters.AddWithValue("@Manvns", manvns);
                }
                else if (tinhHuongTraSach == 2) // Sách hỏng
                {
                    cmd.CommandText = "sp_TraSachHong";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Maphieu", maphieu);
                    cmd.Parameters.AddWithValue("@Masach", masach);
                    cmd.Parameters.AddWithValue("@Manvns", manvns);
                }
                else if (tinhHuongTraSach == 3) // Mất sách
                {
                    // Lấy mã độc giả từ bảng PHIEUMUON
                    string sql = $"SELECT Madg FROM PHIEUMUON WHERE Maphieu = {maphieu}";
                    SqlCommand cmd2 = new SqlCommand(sql, Program.conn);
                    object result = cmd2.ExecuteScalar();
                    if (result == null || !long.TryParse(result.ToString(), out long madg))
                    {
                        MessageBox.Show("Không lấy được mã độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.CommandText = "sp_MatSach";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Maphieu", maphieu);
                    cmd.Parameters.AddWithValue("@Masach", masach);
                    cmd.Parameters.AddWithValue("@Madg", madg);
                    cmd.Parameters.AddWithValue("@Manvns", manvns);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hiện trạng của sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xử lý trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelControl1.Visible = false;

                // Load lại dữ liệu tùy theo loại mượn
                if (isTaiCho)
                    LoadPhieuMuonTaiCho();
                else
                    LoadPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý trả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButtonDONG_Click(object sender, EventArgs e)
        {
            // Ẩn panelControl1
            panelControl1.Visible = false;

            // Làm sạch các trường dữ liệu
            textEditMPS.Text = "";
            textEditSACH.Text = "";
            textEditNVNS.Text = "";

            // Đặt lại các radio button về trạng thái không chọn
            radioButtonTot.Checked = false;
            radioButtonHong.Checked = false;
            radioButtonMat.Checked = false;

            // Reset biến tình trạng trả sách
            tinhHuongTraSach = 0;
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}