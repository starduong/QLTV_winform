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

        private void Frpt_DanhSachTopNDauSachMuonNhieuNhat_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpTuNgay.MaxDate = today;
            dtpDenNgay.MaxDate = today;

            // (Tuỳ chọn) Set mặc định giá trị ban đầu
            dtpTuNgay.Value = today.AddDays(-7);
            dtpDenNgay.Value = today;

        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTuNgay.Value = dtpDenNgay.Value.AddDays(-1); // hoặc gán lại giá trị hợp lệ
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDenNgay.Value = dtpTuNgay.Value.AddDays(1); // hoặc gán lại giá trị hợp lệ
            }
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Lấy ngày từ DateTimePicker
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            int topN = int.Parse(numTopNDauSach.Text);

            // Kiểm tra giá trị topN
            if (topN <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá trị top N phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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