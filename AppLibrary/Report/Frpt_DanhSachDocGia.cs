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
    public partial class Frpt_DanhSachDocGia : DevExpress.XtraEditors.XtraForm
    {
        public Frpt_DanhSachDocGia()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Xrpt_DanhSachDocGia rpDanhSachDocgia = new Xrpt_DanhSachDocGia();
            rpDanhSachDocgia.lblNhanVienLbc.Text = Program.mHoten;

            ReportPrintTool printTool = new ReportPrintTool(rpDanhSachDocgia);
            printTool.ShowPreviewDialog();
        }
    }
}