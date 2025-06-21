using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace AppLibrary
{
    public partial class FormPhieuMuon : DevExpress.XtraEditors.XtraForm
    {
        private HashSet<string> selectedISBNs = new HashSet<string>();

        public FormPhieuMuon()
        {
            InitializeComponent();
        }

        private void FormPhieuMuon_Load(object sender, EventArgs e)
        {
            qLTVDataSet.EnforceConstraints = false;
            this.dOCGIA_HOATDONGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dOCGIA_HOATDONGTableAdapter.Fill(this.qLTVDataSet.DOCGIA_HOATDONG);
            this.sACHCOTHEMUONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sACHCOTHEMUONTableAdapter.Fill(this.qLTVDataSet.SACHCOTHEMUON);
            lupDOCGIAHD.Properties.NullText = "Chọn độc giả...";

            if (!qLTVDataSet.SACHCOTHEMUON.Columns.Contains("LUACHON"))
            {
                qLTVDataSet.SACHCOTHEMUON.Columns.Add("LUACHON", typeof(bool));
                foreach (DataRow row in qLTVDataSet.SACHCOTHEMUON.Rows)
                {
                    row["LUACHON"] = false;
                }
            }

            rbTAICHO.Checked = true;
            UpdateGridControlState();
        }

        int soSachCoTheMuon = 3;

        private void lupDOCGIAHD_EditValueChanged(object sender, EventArgs e)
        {
            string maDG = lupDOCGIAHD.EditValue?.ToString();
            if (string.IsNullOrEmpty(maDG))
            {
                soSachCoTheMuon = 3;
                lblThongBao.Text = "Vui lòng chọn độc giả.";
                return;
            }
            else
            {
                try
                {
                    this.sp_GetSachDangMuon_ByDocGiaTableAdapter.Fill(this.qLTVDataSet.sp_GetSachDangMuon_ByDocGia, maDG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải sách đang mượn của độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                soSachCoTheMuon = 3 - sp_GetSachDangMuon_ByDocGiaBindingSource.Count;

                if (soSachCoTheMuon > 0)
                {
                    lblThongBao.Text = $"Độc giả này có thể mượn về thêm: {soSachCoTheMuon} quyển.";
                }
                else
                {
                    lblThongBao.Text = "Độc giả đã mượn tối đa 3 sách, không thể mượn về thêm.";
                    soSachCoTheMuon = 0;
                }
            }
            ClearAllSelections();
            UpdateGridControlState();
        }

        private void gridViewSACHCOTHEMUON_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "LUACHON" || Convert.ToBoolean(e.Value) == false) return;

            if (rbMUONVE.Checked)
            {
                int checkedCount = selectedISBNs.Count;
                if (checkedCount >= soSachCoTheMuon)
                {
                    XtraMessageBox.Show($"Chỉ được mượn tối đa {soSachCoTheMuon} quyển sách về nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BeginInvoke(new MethodInvoker(() => {
                        gridViewSACHCOTHEMUON.SetRowCellValue(e.RowHandle, e.Column, false);
                    }));
                }
            }
        }

        private void gridViewSACHCOTHEMUON_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "LUACHON") return;
            GridView view = sender as GridView;
            string isbn = view.GetRowCellValue(e.RowHandle, "ISBN")?.ToString();
            if (string.IsNullOrEmpty(isbn)) return;

            if (Convert.ToBoolean(e.Value))
            {
                if (!selectedISBNs.Contains(isbn)) selectedISBNs.Add(isbn);
            }
            else
            {
                if (selectedISBNs.Contains(isbn)) selectedISBNs.Remove(isbn);
            }
            view.RefreshData();
        }

        private void gridViewSACHCOTHEMUON_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null || e.RowHandle < 0) return;

            bool isChecked = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "LUACHON"));
            string currentIsbn = view.GetRowCellValue(e.RowHandle, "ISBN")?.ToString();

            if (isChecked)
            {
                e.Appearance.BackColor = Color.LightYellow;
                return;
            }

            bool limitReached = rbMUONVE.Checked && selectedISBNs.Count >= soSachCoTheMuon;

            if (limitReached)
            {
                e.Appearance.BackColor = Color.Gainsboro;
                e.Appearance.ForeColor = Color.DarkGray;
                return;
            }

            if (!string.IsNullOrEmpty(currentIsbn) && selectedISBNs.Contains(currentIsbn))
            {
                e.Appearance.BackColor = Color.LightGray;
                e.Appearance.ForeColor = Color.DarkGray;
            }
        }

        private void gridViewSACHCOTHEMUON_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName != "LUACHON") return;

            bool isChecked = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, "LUACHON"));
            if (isChecked) return;

            string currentIsbn = view.GetRowCellValue(view.FocusedRowHandle, "ISBN")?.ToString();
            if (!string.IsNullOrEmpty(currentIsbn) && selectedISBNs.Contains(currentIsbn))
            {
                e.Cancel = true;
                return;
            }

            bool limitReached = rbMUONVE.Checked && selectedISBNs.Count >= soSachCoTheMuon;
            if (limitReached)
            {
                e.Cancel = true;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                ClearAllSelections();
                UpdateGridControlState();
            }
        }

        private void UpdateGridControlState()
        {
            bool docGiaDaChon = lupDOCGIAHD.EditValue != null;
            bool coTheMuonVe = docGiaDaChon && soSachCoTheMuon > 0;

            if (rbMUONVE.Checked)
            {
                gcCHONSACH.Enabled = coTheMuonVe;
            }
            else
            {
                gcCHONSACH.Enabled = docGiaDaChon;
            }
        }

        private void ClearAllSelections()
        {
            selectedISBNs.Clear();
            if (qLTVDataSet.SACHCOTHEMUON.Rows.Count > 0)
            {
                foreach (DataRow row in qLTVDataSet.SACHCOTHEMUON.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        row["LUACHON"] = false;
                    }
                }
                qLTVDataSet.SACHCOTHEMUON.AcceptChanges();
            }
            gridViewSACHCOTHEMUON.RefreshData();
        }

        // ========================================================================================
        // === HÀM ĐÃ ĐƯỢC CẬP NHẬT THEO SP MỚI CỦA BẠN ===
        // ========================================================================================
        private void btnLAPPHIEU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // --- VALIDATION (Giữ nguyên) ---
            if (lupDOCGIAHD.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn độc giả để lập phiếu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> selectedMaSach = new List<string>();
            for (int i = 0; i < gridViewSACHCOTHEMUON.DataRowCount; i++)
            {
                if (Convert.ToBoolean(gridViewSACHCOTHEMUON.GetRowCellValue(i, "LUACHON")))
                {
                    selectedMaSach.Add(gridViewSACHCOTHEMUON.GetRowCellValue(i, "MASACH").ToString());
                }
            }

            if (selectedMaSach.Count == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn ít nhất một quyển sách để mượn!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- DATA PREPARATION (Giữ nguyên) ---
            long maDG;
            if (!long.TryParse(lupDOCGIAHD.EditValue.ToString(), out maDG))
            {
                XtraMessageBox.Show("Mã độc giả không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maNV;
            if (!int.TryParse(Program.UserName, out maNV))
            {
                XtraMessageBox.Show("Mã nhân viên đăng nhập không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool hinhThuc = rbMUONVE.Checked;

            // --- DATABASE EXECUTION (Phần được thay đổi) ---
            if (MessageBox.Show($"Bạn có chắc muốn lập phiếu mượn cho {selectedMaSach.Count} quyển sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Program.connstr))
                {
                    conn.Open();
                    // Bắt đầu một Transaction ngay trong code C#
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // -- BƯỚC 1: TẠO PHIẾU MƯỢN MỚI (CHỈ 1 LẦN) --
                        // Gộp lệnh INSERT và SELECT SCOPE_IDENTITY() để lấy mã phiếu mới tạo
                        string sqlInsertPhieuMuon = @"
                    INSERT INTO PHIEUMUON (MADG, HINHTHUC, NGAYMUON, MANV)
                    VALUES (@MaDG, @HinhThuc, GETDATE(), @MaNV);
                    SELECT SCOPE_IDENTITY();";

                        long newMaPhieu;
                        using (SqlCommand cmdPhieuMuon = new SqlCommand(sqlInsertPhieuMuon, conn, transaction))
                        {
                            cmdPhieuMuon.Parameters.AddWithValue("@MaDG", maDG);
                            cmdPhieuMuon.Parameters.AddWithValue("@HinhThuc", hinhThuc);
                            cmdPhieuMuon.Parameters.AddWithValue("@MaNV", maNV);

                            // ExecuteScalar dùng để thực thi lệnh và trả về giá trị của cột đầu tiên, dòng đầu tiên (chính là mã phiếu mới)
                            newMaPhieu = Convert.ToInt64(cmdPhieuMuon.ExecuteScalar());
                        }

                        // -- BƯỚC 2: INSERT CHI TIẾT PHIẾU MƯỢN VÀ UPDATE SÁCH (LẶP THEO SỐ SÁCH) --
                        string sqlInsertCT = "INSERT INTO CT_PHIEUMUON (MAPHIEU, MASACH, TRA) VALUES (@MaPhieu, @MaSach, 0);";
                        string sqlUpdateSach = "UPDATE SACH SET CHOMUON = 1 WHERE MASACH = @MaSach;";

                        // Lặp qua danh sách sách đã chọn
                        foreach (string maSach in selectedMaSach)
                        {
                            // Thêm chi tiết phiếu mượn
                            using (SqlCommand cmdCT = new SqlCommand(sqlInsertCT, conn, transaction))
                            {
                                cmdCT.Parameters.AddWithValue("@MaPhieu", newMaPhieu);
                                cmdCT.Parameters.AddWithValue("@MaSach", maSach);
                                cmdCT.ExecuteNonQuery();
                            }

                            // Cập nhật trạng thái sách
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateSach, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@MaSach", maSach);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }

                        // Nếu tất cả các lệnh trên thành công, xác nhận transaction để lưu vĩnh viễn
                        transaction.Commit();
                        XtraMessageBox.Show("Lập phiếu mượn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // --- POST-ACTION CLEANUP & REFRESH ---
                        ClearAllSelections();
                        this.sACHCOTHEMUONTableAdapter.Fill(this.qLTVDataSet.SACHCOTHEMUON);
                        lupDOCGIAHD_EditValueChanged(lupDOCGIAHD, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        // Nếu có bất kỳ lỗi nào xảy ra, hoàn tác lại toàn bộ transaction
                        transaction.Rollback();
                        XtraMessageBox.Show("Đã xảy ra lỗi khi lập phiếu mượn. Mọi thay đổi đã được hoàn tác.\nLỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } // using sẽ tự động đóng connection
            }
        }

        private void btnREFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Tắt kiểm tra ràng buộc để tránh lỗi khi nạp lại dữ liệu
            qLTVDataSet.EnforceConstraints = false;

            // Nạp lại danh sách độc giả và sách có thể mượn
            this.dOCGIA_HOATDONGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dOCGIA_HOATDONGTableAdapter.Fill(this.qLTVDataSet.DOCGIA_HOATDONG);

            this.sACHCOTHEMUONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sACHCOTHEMUONTableAdapter.Fill(this.qLTVDataSet.SACHCOTHEMUON);

            // --- BẮT ĐẦU PHẦN RESET TRẠNG THÁI FORM ---

            // 1. Reset ô chọn độc giả
            lupDOCGIAHD.EditValue = null;
            lupDOCGIAHD.Properties.NullText = "Chọn độc giả...";

            // 2. Xóa sạch dữ liệu trong bảng sách đang mượn của độc giả cũ
            // Đây là bước quan trọng để đảm bảo không còn dữ liệu cũ
            qLTVDataSet.sp_GetSachDangMuon_ByDocGia.Clear();

            // 3. Reset thông báo và biến đếm số sách có thể mượn
            lblThongBao.Text = "Vui lòng chọn độc giả.";
            // **SỬA LỖI CHÍNH: Reset biến soSachCoTheMuon về giá trị mặc định**
            soSachCoTheMuon = 3;

            // 4. Đặt lại hình thức mượn về mặc định
            rbTAICHO.Checked = true;

            // 5. Bỏ chọn tất cả các sách trong grid
            ClearAllSelections();

            // 6. Cập nhật trạng thái của các control (ví dụ: enable/disable grid sách)
            UpdateGridControlState();

            // Bật lại kiểm tra ràng buộc sau khi đã hoàn tất
            qLTVDataSet.EnforceConstraints = true;
        }

        private void btnTHOAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void rbMUONVE_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged(sender, e);
        }

        private void rbTAICHO_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_CheckedChanged(sender, e);
        }
        private void gridViewSACHDGCHUATRA_RowStyle(object sender, RowStyleEventArgs e)
        {

        }

        private void gridViewSACHDGCHUATRA_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void gcINPUTPM_Paint(object sender, PaintEventArgs e)
        {

        }

    }

}