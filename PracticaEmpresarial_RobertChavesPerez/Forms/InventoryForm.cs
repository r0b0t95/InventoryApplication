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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class InventoryForm : Form
    {
        private Logica.Models.Product product;

        private Logica.Models.Code code;

        private Logica.Models.Logg log;

        private DataTable dtProductList { set; get; }

        private DataTable dtCodeList { set; get; }

        private long tempProductId { set; get; }

        private long tempCodeId { set; get; }

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
            this.DialogResult = DialogResult.OK;
        }
        

        public void fillProductDgv()
        {
            dtProductList = product.list( cbActivos.Checked, txtSearchProduct.Text.Trim() );

            dgvList.DataSource = dtProductList;

            refreshButtons();
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
            cleanTemp();
            refreshButtons();
        }

        private void cleanTemp()
        {
            tempProductId = 0;
            tempCodeId = 0;
        }

        private void refreshButtons()
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
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
            DialogResult result = MessageBox.Show( "Quieres agregar varios codigos?", "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            if ( result.Equals( DialogResult.Yes ) ) 
            {
                CodeForm codeForm = new CodeForm();

                DialogResult resp = codeForm.ShowDialog();

                if ( resp == DialogResult.OK ) fillCodeDgv();
            }
            else
            {
                new CodeForm().Show();
            }

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

                tempCodeId = Convert.ToInt64( row.Cells["CcodeId"].Value );
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) && tempProductId <= 0 )
            {
                product = new Logica.Models.Product();

                product.detail = txtDetail.Text.Trim();
                product.cant = Convert.ToInt32( txtCant.Text.Trim() );
                product.price = ( double ) Convert.ToDecimal( txtPrice.Text.Trim() );
                product.code.codeId = tempCodeId;
                product.state.stateId = 1;

                string text = "Quieres agregar al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.addProduct();

                    if ( ok )
                    {
                        string detail = string.Format( "Agrego al producto: {0}", product.detail );

                        addLogEvent(detail);

                        MessageBox.Show( "Producto agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        fillProductDgv();
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void addLogEvent( string detail )
        {
            log = new Logica.Models.Logg();
            log.user.userId = Globals.GlobalUser.userId;
            log.logDetail = detail;
            log.logDate = DateTime.Now;

            log.addLog();
        }

        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtCode.Text.Trim() ) )
            {
                return string.Format( responce, "codigo" );
            }

            if ( string.IsNullOrWhiteSpace( txtPrice.Text.Trim() ) )
            {
                return string.Format( responce, "precio" );
            }

            if ( string.IsNullOrWhiteSpace( txtCant.Text.Trim() ) )
            {
                return string.Format( responce, "cantidad" );
            }

            if ( string.IsNullOrWhiteSpace( txtDetail.Text.Trim() ) )
            {
                return string.Format( responce, "detalle" );
            }

            return string.Empty;
        }

        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result == DialogResult.Yes ? true : false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            product = new Logica.Models.Product();

            product.productId = tempProductId;
            product.detail = txtDetail.Text.Trim();
            product.cant = Convert.ToInt32(txtCant.Text.Trim());
            product.price = (double)Convert.ToDecimal(txtPrice.Text.Trim());
            product.code.codeId = tempCodeId; ;
            product.state.stateId = 1;

            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) && tempProductId > 0 )
            {
                string text = "Quieres actualizar al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.updateProduct();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al producto: {0}", product.detail );

                        addLogEvent(detail);

                        MessageBox.Show( "Producto actualizado correctamente", ":)", MessageBoxButtons.OK ) ;

                        cleanFields();

                        fillProductDgv();
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el Producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = dgvList.SelectedRows[0];

                tempProductId = Convert.ToInt64( row.Cells["CproductId"].Value );
                txtCode.Text = row.Cells["CpCode"].Value.ToString().Trim();
                txtDetail.Text = row.Cells["CproductDetail"].Value.ToString().Trim();
                txtCant.Text = row.Cells["Ccant"].Value.ToString().Trim();
                txtPrice.Text = row.Cells["Cprice"].Value.ToString().Trim();
                tempCodeId = Convert.ToInt64( row.Cells["CpCodeId"].Value );

                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( tempProductId > 0 )
            {
                product = new Logica.Models.Product();

                product.productId = tempProductId;
                product.detail = txtDetail.Text.Trim();
                product.state.stateId = 2;
                
                string text = "Quieres eliminar al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.deleteProduct();

                    if ( ok )
                    {
                        string detail = string.Format( "Elimino al producto: {0}", product.detail );

                        addLogEvent(detail);

                        MessageBox.Show( "Producto fue eliminado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        fillProductDgv();
                    }
                    else
                    {
                        MessageBox.Show( "No se elimino el producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
            else
            {
                MessageBox.Show( "Selecciona el producto que desea eliminar", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
            } 

        }

    }
}
