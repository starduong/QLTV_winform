using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AppLibrary.Report
{
    public partial class Xrpt_DanhSachTopNDauSachMuonNhieuNhat : DevExpress.XtraReports.UI.XtraReport
    {

        public Xrpt_DanhSachTopNDauSachMuonNhieuNhat(DateTime tuNgay, DateTime denNgay, int topN)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = tuNgay;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = denNgay;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = topN;
            this.sqlDataSource1.Fill();
        }

    }
}
