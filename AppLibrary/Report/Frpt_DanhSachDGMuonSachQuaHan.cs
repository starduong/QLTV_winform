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
    public partial class Frpt_DanhSachDGMuonSachQuaHan : DevExpress.XtraEditors.XtraForm
    {
        public Frpt_DanhSachDGMuonSachQuaHan()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Xrpt_DanhSachDGMuonSachQuaHan rpDanhSachDGMuonSachQuaHan = new Xrpt_DanhSachDGMuonSachQuaHan();
            rpDanhSachDGMuonSachQuaHan.lblNhanVienlbc.Text = Program.mHoten;

            ReportPrintTool printTool = new ReportPrintTool(rpDanhSachDGMuonSachQuaHan);
            printTool.ShowPreviewDialog();
        }
    }
}