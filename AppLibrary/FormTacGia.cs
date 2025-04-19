using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLibrary
{
    public partial class FormTacGia : Form
    {
        public FormTacGia()
        {
            InitializeComponent();
        }

        private void nHANVIENGridControl_Click(object sender, EventArgs e)
        {

        }

        private void tACGIABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tACGIABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLTVDataSet);

        }

        private void FormTacGia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTVDataSet.TACGIA' table. You can move, or remove it, as needed.
            this.tACGIATableAdapter.Fill(this.qLTVDataSet.TACGIA);

        }
    }
}
