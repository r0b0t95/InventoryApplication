using Logica.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class InventoryForm : Form
    {
        Logica.Models.Product product;

        Logica.Models.Code code;

        DataTable dtProductList { set; get; }

        DataTable dtCodeList { set; get; }

        public InventoryForm()
        {
            InitializeComponent();

            product = new Logica.Models.Product();

            code = new Logica.Models.Code();

            dtProductList = new DataTable();

            dtCodeList = new DataTable();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        public void fillProductDgv()
        {
            dtProductList = product.list( cbActivos.Checked, txtSearchProduct.Text.Trim() );

            dgvList.DataSource = dtProductList;
        }

        public void fillCodeDgv()
        {
            dtCodeList = code.list( txtSearchCode.Text.Trim() );

            dgvCodeList.DataSource = dtCodeList;
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            fillCodeDgv();
            fillProductDgv();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearchProduct.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearchProduct.Text.Trim() ) )
            {
                fillProductDgv();
            }
        }

        private void cleanFields()
        {
            txtCode.Text = string.Empty;
            txtCant.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDetail.Text = string.Empty;
            txtSearchCode.Text = string.Empty;
            txtSearchProduct.Text = string.Empty;
        }

        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearchCode.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearchCode.Text.Trim() ) )
            {
                fillCodeDgv();
            }
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            new CodeForm().Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillCodeDgv();
            fillProductDgv();
            cleanFields();
        }

        private void dgvCodeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvCodeList.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = dgvCodeList.SelectedRows[0];

                string code = row.Cells["Ccode"].Value.ToString();

                txtCode.Text = code;
            }
        }

        private void dgvCodeList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvCodeList.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = dgvCodeList.SelectedRows[0];

                long codeId = Convert.ToInt64(row.Cells["CcodeId"].Value);
                string code = row.Cells["Ccode"].Value.ToString();

                CodeForm codeForm = new CodeForm();
                codeForm.tempId = codeId;
                codeForm.txtCode.Text = code;

                DialogResult resp = codeForm.ShowDialog();

                if ( resp == DialogResult.OK ) {
                    fillCodeDgv();
                    txtCode.Text = string.Empty;
                }

            }

        }


    }
}
