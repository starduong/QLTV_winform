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
            this.tableAdapterManager.Connection.ConnectionString = Program.connstr;
            try
            {
                this.tableAdapterManager.Connection.ConnectionString = Program.connstr;
                this.dAUSACHTableAdapter.Fill(this.qLTVDataSet.DAUSACH);

            }
            catch (System.Data.ConstraintException ex)
            {
                MessageBox.Show("Lỗi dữ liệu: " + ex.Message);
            }
        }

        private void dAUSACHGridControl_Click(object sender, EventArgs e)
        {

        }

        private void dAUSACHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dAUSACHBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLTVDataSet);

        }

        private void gc_DauSach_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}