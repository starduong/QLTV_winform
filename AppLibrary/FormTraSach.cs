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
                LoadPhieuMuon(); // Refresh dữ liệu sau khi xử lý
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý trả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}