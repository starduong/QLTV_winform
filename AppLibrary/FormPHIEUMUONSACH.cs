using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using AppLibrary.QLTVDataSetTableAdapters;
using System.Data.SqlClient;

namespace AppLibrary
{
    public partial class FormPHIEUMUONSACH : Form
    {



        public FormPHIEUMUONSACH()
        {
            InitializeComponent();
            Load += FormPhieuMuonSach_Load;
        }
        private int LayMaPhieuTiepTheo()
        {
            int nextMaphieu = 0;
            string sql = "SELECT IDENT_CURRENT('PHIEUMUON') + IDENT_INCR('PHIEUMUON')";

            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                {
                    if (Program.KetNoi() == 0)
                    {
                        MessageBox.Show("Không thể kết nối tới cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1; // Trả về -1 để biết là lỗi
                    }
                }

                using (SqlCommand cmd = new SqlCommand(sql, Program.conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        nextMaphieu = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return nextMaphieu;
        }

        private void FormPhieuMuonSach_Load(object sender, EventArgs e)
        {
            qLTVDataSet.EnforceConstraints = false;
            pHIEUMUONTableAdapter.Fill(qLTVDataSet.PHIEUMUON);
            sachTableAdapter = new QLTVDataSetTableAdapters.SACHTableAdapter();
            dauSachTableAdapter = new QLTVDataSetTableAdapters.DAUSACHTableAdapter();
            ctPhieuMuonTableAdapter = new QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter();
            docGiaTableAdapter = new QLTVDataSetTableAdapters.DOCGIATableAdapter();
            NHANVIENTableAdapter = new QLTVDataSetTableAdapters.NHANVIENTableAdapter();
            NHANVIENTableAdapter.Fill(qLTVDataSet.NHANVIEN);

            sachTableAdapter.Fill(qLTVDataSet.SACH);
            dauSachTableAdapter.Fill(qLTVDataSet.DAUSACH);
            docGiaTableAdapter.Fill(qLTVDataSet.DOCGIA);



            mANVTextEdit.Text = Program.mHoten;
            mANVTextEdit.ReadOnly = true;
            mAPHIEUTextEdit.ReadOnly = true;
            mAPHIEUTextEdit.Text = LayMaPhieuTiepTheo() > 0 ? LayMaPhieuTiepTheo().ToString() : "";

            LoadComboBoxDocGia();
            LoadComboBoxSach();

            hINHTHUCRadioButton.Checked = true;
            radioButton1.Checked = false;
            panelControl1.Visible = false;
            gridControl1.Visible = false;

        }

        private void LoadComboBoxDocGia()
        {
            DataTable dt = Program.ExecuteSqlDataTable("EXEC sp_LoadComboDocGia");
            comboBoxEditMaDG.Properties.DataSource = dt;
            dt.Columns.Add("FullName", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["FullName"] = row["HODG"].ToString() + " " + row["TENDG"].ToString();
            }
            comboBoxEditMaDG.Properties.ValueMember = "MADG";
            comboBoxEditMaDG.Properties.DisplayMember = "FullName";
            comboBoxEditMaDG.Properties.TextEditStyle = TextEditStyles.Standard;
            comboBoxEditMaDG.Properties.SearchMode = SearchMode.AutoComplete;
            comboBoxEditMaDG.Properties.AutoSearchColumnIndex = 0;
            comboBoxEditMaDG.Properties.NullText = "Chọn độc giả...";
        }



        private void LoadComboBoxSach()
        {
            DataTable dt = Program.ExecuteSqlDataTable("EXEC sp_LoadComboSach");
            comboBoxEditSach.Properties.DataSource = dt;
            comboBoxEditSach.Properties.ValueMember = "MASACH";
            comboBoxEditSach.Properties.DisplayMember = "TENSACH";
            comboBoxEditSach.Properties.TextEditStyle = TextEditStyles.Standard;
            comboBoxEditSach.Properties.SearchMode = SearchMode.AutoComplete;
            comboBoxEditSach.Properties.AutoSearchColumnIndex = 0;
            comboBoxEditSach.Properties.NullText = "Chọn sách...";
        }

        private void hINHTHUCRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !hINHTHUCRadioButton.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hINHTHUCRadioButton.Checked = !radioButton1.Checked;
        }
        private void RefreshData()
        {
            qLTVDataSet.Clear();
            pHIEUMUONTableAdapter.Fill(qLTVDataSet.PHIEUMUON);
            sachTableAdapter.Fill(qLTVDataSet.SACH);
            dauSachTableAdapter.Fill(qLTVDataSet.DAUSACH);
            ctPhieuMuonTableAdapter.Fill(qLTVDataSet.CT_PHIEUMUON);

            comboBoxEditMaDG.EditValue = null;
            comboBoxEditSach.EditValue = null;

        }

        private void buttonLapPhieu_Click_1(object sender, EventArgs e)
        {
            if (comboBoxEditMaDG.EditValue == null || comboBoxEditSach.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.KetNoi(); // Đảm bảo luôn mở kết nối

                SqlCommand cmd = new SqlCommand("sp_LapPhieuMuon", Program.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaDG", comboBoxEditMaDG.EditValue);
                cmd.Parameters.AddWithValue("@MaSach", comboBoxEditSach.EditValue.ToString());
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(Program.UserName));
                cmd.Parameters.AddWithValue("@HinhThuc", hINHTHUCRadioButton.Checked);

                cmd.ExecuteNonQuery(); // Gọi SP

                MessageBox.Show("Lập phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void barButtonLPMS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Visible = true;
        }

        private void barButtonHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonRefresh_ItemClick(sender, e);
            panelControl1.Visible = false;
            gridControl1.Visible = false;
        }

        private void barButtonRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Clear toàn bộ dataset
                qLTVDataSet.Clear();

                // Nạp lại dữ liệu từ database
                pHIEUMUONTableAdapter.Fill(qLTVDataSet.PHIEUMUON);
                sachTableAdapter.Fill(qLTVDataSet.SACH);
                dauSachTableAdapter.Fill(qLTVDataSet.DAUSACH);
                ctPhieuMuonTableAdapter.Fill(qLTVDataSet.CT_PHIEUMUON);
                docGiaTableAdapter.Fill(qLTVDataSet.DOCGIA);
                NHANVIENTableAdapter.Fill(qLTVDataSet.NHANVIEN);
                // Load lại comboBox
                LoadComboBoxDocGia();
                LoadComboBoxSach();

                mAPHIEUTextEdit.Text = LayMaPhieuTiepTheo() > 0 ? LayMaPhieuTiepTheo().ToString() : "";
                mANVTextEdit.Text = Program.mHoten;
                comboBoxEditMaDG.EditValue = null;
                comboBoxEditSach.EditValue = null;
                hINHTHUCRadioButton.Checked = false;
                radioButton1.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPhieuMuonTheoDocGia(int maDG)
        {
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.KetNoi();

                SqlCommand cmd = new SqlCommand("sp_GetPhieuMuon_ByDocGia", Program.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDG", maDG);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridControl1.DataSource = dt;

                gridControl1.MainView.PopulateColumns();
                gridView1.Columns["MAPHIEU"].Caption = "Mã phiếu";
                gridView1.Columns["TenDocGia"].Caption = "Tên độc giả";
                gridView1.Columns["HinhThuc"].Caption = "Hình thức";
                gridView1.Columns["NgayMuon"].Caption = "Ngày mượn";
                gridView1.Columns["HoTenNV"].Caption = "Nhân viên lập phiếu";
                gridView1.Columns["TrangThaiTra"].Caption = "Trạng thái";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEditMaDG_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEditMaDG.EditValue == null)
            {
                gridControl1.DataSource = null;
                gridControl1.Visible = false;
                return;
            }

            if (int.TryParse(comboBoxEditMaDG.EditValue.ToString(), out int maDG))
            {
                LoadPhieuMuonTheoDocGia(maDG);
                gridControl1.Visible = true;
                gridView1.OptionsBehavior.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Mã độc giả không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}