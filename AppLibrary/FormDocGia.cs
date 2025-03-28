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
    public partial class FormDocGia : DevExpress.XtraEditors.XtraForm
    {
        public FormDocGia()
        {
            InitializeComponent();
        }

        private void dAUSACHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void dOCGIABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bds_DocGia.EndEdit();
            this.tam_DocGia.UpdateAll(this.ds_QLTV);

        }

        private void FormDocGia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds_QLTV.DOCGIA' table. You can move, or remove it, as needed.
            this.ta_DocGia.Fill(this.ds_QLTV.DOCGIA);
            this.ta_DocGia.Connection.ConnectionString = Program.connstr;
            this.ta_DocGia.Fill(this.ds_QLTV.DOCGIA);
        }
    }
}