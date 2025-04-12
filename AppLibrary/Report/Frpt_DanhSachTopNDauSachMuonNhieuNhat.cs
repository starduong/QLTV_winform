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
using DevExpress.XtraReports.UI;

namespace AppLibrary.Report
{
    public partial class Frpt_DanhSachTopNDauSachMuonNhieuNhat : DevExpress.XtraEditors.XtraForm
    {
        public Frpt_DanhSachTopNDauSachMuonNhieuNhat()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Lấy ngày từ DateTimePicker
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            int topN = int.Parse(numTopNDauSach.Text);

            // Tạo báo cáo
            Xrpt_DanhSachTopNDauSachMuonNhieuNhat rpDanhSachTopNDauSachMuonNhieuNhat = new Xrpt_DanhSachTopNDauSachMuonNhieuNhat(tuNgay, denNgay, topN);
            // Đặt tiêu đề báo cáo
            rpDanhSachTopNDauSachMuonNhieuNhat.lblTieuDe.Text = "DANH SÁCH TOP " + topN + " ĐẦU SÁCH MƯỢN NHIỀU NHẤT";
            // Đặt ngày tháng vào nhãn
            rpDanhSachTopNDauSachMuonNhieuNhat.lblTuNgay.Text = tuNgay.ToString("dd/MM/yyyy");
            rpDanhSachTopNDauSachMuonNhieuNhat.lblDenNgay.Text = denNgay.ToString("dd/MM/yyyy");
            // Đặt tên nhân viên vào nhãn
            rpDanhSachTopNDauSachMuonNhieuNhat.lblNhanVienlbc.Text = Program.mHoten;
            // Tạo công cụ in báo cáo
            ReportPrintTool printTool = new ReportPrintTool(rpDanhSachTopNDauSachMuonNhieuNhat);
            // Hiển thị hộp thoại xem trước báo cáo
            printTool.ShowPreviewDialog();
        }
    }
}