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
	public partial class Frpt_DanhSachDauSach: DevExpress.XtraEditors.XtraForm
	{
        public Frpt_DanhSachDauSach()
		{
            InitializeComponent();
		}

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Xrpt_DanhSachDauSach rpDanhSachDauSach = new Xrpt_DanhSachDauSach();
            rpDanhSachDauSach.lblNhanVienlbc.Text = Program.mHoten;

            ReportPrintTool printTool = new ReportPrintTool(rpDanhSachDauSach);
            printTool.ShowPreviewDialog();
        }
    }
}