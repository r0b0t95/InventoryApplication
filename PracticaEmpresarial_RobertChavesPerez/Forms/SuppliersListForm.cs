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
            SuppliersForm supplierForm = new SuppliersForm();

            DialogResult resp = supplierForm.ShowDialog();

            if ( resp == DialogResult.OK ) fillDgv();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvList.SelectedRows[0];

                long supplierId = Convert.ToInt64(row.Cells["CsupplierId"].Value);
                string supplierName = row.Cells["CsupplierName"].Value.ToString();
                string supplierTel = row.Cells["CsupplierTel"].Value.ToString();
                string supplierEmail = row.Cells["CsupplierEmail"].Value.ToString();
                string supplierDescription = row.Cells["CsupplierDescription"].Value.ToString();

                SuppliersForm supplierForm = new SuppliersForm();
                supplierForm.tempId = supplierId;
                supplierForm.txtName.Text = supplierName.ToString();
                supplierForm.txtTel.Text = supplierTel.ToString();
                supplierForm.txtEmail.Text = supplierEmail.ToString();
                supplierForm.txtDescription.Text = supplierDescription.ToString();

                DialogResult resp = supplierForm.ShowDialog();

                if (resp == DialogResult.OK) fillDgv();

            }
        }


    }
}
