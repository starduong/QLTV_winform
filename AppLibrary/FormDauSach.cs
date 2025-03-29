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

namespace AppLibrary
{
    public partial class FormDauSach : DevExpress.XtraEditors.XtraForm
    {
        public FormDauSach()
        {
            InitializeComponent();
        }

        private void FormDauSach_Load(object sender, EventArgs e)
        {
            dsQLVT.EnforceConstraints = false;
            this.taChiTietNganTu.Connection.ConnectionString =Program.connstr;
            this.taChiTietNganTu.Fill(this.dsQLVT.CHITIETNGANTU);
            this.taDSTheLoai.Connection.ConnectionString =Program.connstr;
            this.taDSTheLoai.Fill(this.dsQLVT.DSTHELOAI);
            this.taDSNgonNgu.Connection.ConnectionString =Program.connstr;
            this.taDSNgonNgu.Fill(this.dsQLVT.DSNGONNGU);
            this.tamDauSach.Connection.ConnectionString = Program.connstr;
            this.taDauSach.Fill(this.dsQLVT.DAUSACH);
            this.taSach.Connection.ConnectionString = Program.connstr;
            this.taSach.Fill(this.dsQLVT.SACH);
        }

        private void cbNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNgonNgu.Text = cbNgonNgu.SelectedValue?.ToString() ?? string.Empty;
            }
            catch { }
        }

        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaTheLoai.Text = cbTheLoai.SelectedValue?.ToString() ?? string.Empty;
            }
            catch { }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            bdsSach.AddNew();
        }

        private void btnGhiSach_Click(object sender, EventArgs e)
        {
            try 
            {
                this.taSach.Update(this.dsQLVT.SACH);
            } catch (Exception){ }
        }
    }

}