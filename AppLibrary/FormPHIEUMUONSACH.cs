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
                MessageBox.Show("Lỗi lấy mã phiếu tiếp theo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            sachTableAdapter.Fill(qLTVDataSet.SACH);
            dauSachTableAdapter.Fill(qLTVDataSet.DAUSACH);
            docGiaTableAdapter.Fill(qLTVDataSet.DOCGIA);



            mANVTextEdit.Text = Program.UserName;
            mANVTextEdit.ReadOnly = true;
            mAPHIEUTextEdit.ReadOnly = true;
            mAPHIEUTextEdit.Text = LayMaPhieuTiepTheo() > 0 ? LayMaPhieuTiepTheo().ToString() : "";

            LoadComboBoxDocGia();
            LoadComboBoxSach();

            hINHTHUCRadioButton.Checked = true;
            radioButton1.Checked = false;
            panelControl1.Visible = false;


        }

        private void LoadComboBoxDocGia()
        {
            DataTable dt = Program.ExecuteSqlDataTable("EXEC sp_LoadComboDocGia");
            comboBoxEditMaDG.Properties.DataSource = dt;
            comboBoxEditMaDG.Properties.DisplayMember = "DisplayText";
            comboBoxEditMaDG.Properties.ValueMember = "MADG";
            comboBoxEditMaDG.Properties.TextEditStyle = TextEditStyles.Standard;
            comboBoxEditMaDG.Properties.SearchMode = SearchMode.AutoComplete;
            comboBoxEditMaDG.Properties.AutoSearchColumnIndex = 0;
            comboBoxEditMaDG.Properties.NullText = "Chọn độc giả...";
        }



        private void LoadComboBoxSach()
        {
            DataTable dt = Program.ExecuteSqlDataTable("EXEC sp_LoadComboSach");
            comboBoxEditSach.Properties.DataSource = dt;
            comboBoxEditSach.Properties.DisplayMember = "DisplayText";
            comboBoxEditSach.Properties.ValueMember = "MASACH";
            comboBoxEditSach.Properties.TextEditStyle = TextEditStyles.Standard;
            comboBoxEditSach.Properties.SearchMode = SearchMode.AutoComplete;
            comboBoxEditSach.Properties.AutoSearchColumnIndex = 0;
            comboBoxEditSach.Properties.NullText = "Chọn sách...";
        }


        private void comboBoxEditSach_EditValueChanged(object sender, EventArgs e) //Load ảnh khi chọn sách 
        {
            if (comboBoxEditSach.EditValue != null && comboBoxEditSach.EditValue.ToString() != string.Empty)
            {
                string masach = comboBoxEditSach.EditValue.ToString();
                var sachRow = qLTVDataSet.SACH.FindByMASACH(masach);
                if (sachRow != null)
                {
                    var dauSachRow = qLTVDataSet.DAUSACH.FindByISBN(sachRow.ISBN);
                    if (dauSachRow != null && !dauSachRow.IsHINHANHPATHNull())
                    {
                        try
                        {
                            string relativePath = dauSachRow.HINHANHPATH.Replace("/", "\\");
                            string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                            string fullPath = Path.Combine(projectRoot, relativePath);

                            if (File.Exists(fullPath))
                            {
                                pictureEditSach.Image = Image.FromFile(fullPath);
                            }
                            else
                            {
                                pictureEditSach.Image = null;
                              
                            }
                        }
                        catch (Exception ex)
                        {
                            pictureEditSach.Image = null;
                            MessageBox.Show("Lỗi load ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        pictureEditSach.Image = null; // Nếu sách không có hình
                    }
                }
                else
                {
                    pictureEditSach.Image = null; // Nếu MASACH không tìm thấy
                }
            }
            else
            {
                pictureEditSach.Image = null; // Nếu EditValue = null
            }
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
            pictureEditSach.Image = null;
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
                MessageBox.Show("Lỗi khi lập phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Load lại comboBox
                LoadComboBoxDocGia();
                LoadComboBoxSach();

                mAPHIEUTextEdit.Text = LayMaPhieuTiepTheo() > 0 ? LayMaPhieuTiepTheo().ToString() : "";
                mANVTextEdit.Text = Program.UserName;
                comboBoxEditMaDG.EditValue = null;
                comboBoxEditSach.EditValue = null;
                pictureEditSach.Image = null;
                hINHTHUCRadioButton.Checked = false; 
                radioButton1.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
