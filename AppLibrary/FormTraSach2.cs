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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace AppLibrary
{
	public partial class FormTraSach2: DevExpress.XtraEditors.XtraForm
	{
        public FormTraSach2()
		{
            InitializeComponent();
		}

        private void FormTraSach2_Load(object sender, EventArgs e)
        {
            qLTVDataSet.EnforceConstraints = false;
            this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter.Fill(this.qLTVDataSet.sp_GetPhieuMuonChiTietTheoHinhThuc, new System.Nullable<bool>(((bool)(System.Convert.ChangeType(1, typeof(bool))))));
            gvCTPMHINHTHUC.OptionsView.ShowGroupPanel = false;
            gvCTPMHINHTHUC.OptionsFind.AlwaysVisible = true;  // Hiện ô tìm kiếm
            gvCTPMHINHTHUC.OptionsFind.FindNullPrompt = "Nhập thông tin tìm kiếm..."; // Placeholder ô tìm kiếm

        }

        private void btnSHOWDATA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool on = (btnSHOWDATA.Caption == "TẠI CHỖ CHƯA TRẢ");
            gcDISPLAY.Text = on ? "DANH SÁCH PHIẾU MƯỢN TẠI CHỖ CHƯA TRẢ" : "DANH SÁCH PHIẾU MƯỢN MƯỢN VỀ CHƯA TRẢ";
            btnSHOWDATA.Caption = on ? "MƯỢN VỀ CHƯA TRẢ" : "TẠI CHỖ CHƯA TRẢ";
            try
            {
                qLTVDataSet.EnforceConstraints = false;
                this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter.Fill(this.qLTVDataSet.sp_GetPhieuMuonChiTietTheoHinhThuc, new System.Nullable<bool>(((bool)(System.Convert.ChangeType(on, typeof(bool))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void rbTOT_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}