using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class SuppliersListForm : Form
    {
        Logica.Models.Supplier supplier;
        
        DataTable dtList { get; set; }

        public SuppliersListForm()
        {
            InitializeComponent();

            supplier = new Logica.Models.Supplier();

            dtList = new DataTable();
        }

        private void SuppliersListForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }

        public void fillDgv()
        {
            dtList = supplier.list( true, txtSearch.Text.Trim() );

            dgvList.DataSource = dtList;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearch.Text.Count() > 2  ||
                    string.IsNullOrEmpty( txtSearch.Text.Trim() ) ) 
            {
                fillDgv();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new SuppliersForm().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
