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

        private int tempState { set; get; }

        private string[] deleteVector { get; set; }

        public bool showItems { get; set; }


        public InventoryForm()
        {
            InitializeComponent();

            product = new Logica.Models.Product();

            code = new Logica.Models.Code();

            log = new Logica.Models.Logg();

            dtProductList = new DataTable();

            dtCodeList = new DataTable();

            deleteVector = new string[4];
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        

        public void fillProductDgv()
        {
            int active = cbActive();

            dtProductList = product.list( active, txtSearchProduct.Text.Trim() );

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
            showItemsMethod();
            fillCodeDgv();
            fillProductDgv();
        }


        private void showItemsMethod()
        {
            if ( showItems )
            {
                inventory();
            }
            else
            {
                chooseItem();
            }
        }


        private void inventory()
        {
            lblCode.Visible = true;
            lblPrice.Visible = true;
            lblDetail.Visible = true;
            btnUpdate.Visible = true;
            btnAddCode.Visible = true;
            btnSave.Visible = true;
            btnRemoveCode.Visible = true;
            txtCode.Visible = true;
            txtPrice.Visible = true;
            txtDetail.Visible = true;
            txtSearchCode.Visible = true;
            txtCant.Location = new System.Drawing.Point( 141, 651 );
            lblCant.Location = new System.Drawing.Point( 47, 660 );
            dgvCodeList.Visible = true;
            btnRefresh.BackColor = Color.FromArgb( 192, 192, 0 );
            btnRefresh.ForeColor = Color.FromArgb( 30, 30, 30);
            btnRefresh.Location = new System.Drawing.Point( 989, 21 );
            btnRefresh.Text = "Refrescar";
            btnRefresh.Enabled = true;
            dgvList.Size = new System.Drawing.Size( 1249, 421 );
        }


        private void chooseItem()
        {
            lblCode.Visible = false;
            lblPrice.Visible = false;
            lblDetail.Visible = false;
            btnUpdate.Visible = false;
            btnAddCode.Visible = false;
            btnSave.Visible = false;
            btnRemoveCode.Visible = false;
            txtCode.Visible = false;
            txtPrice.Visible = false;
            txtDetail.Visible = false;
            txtSearchCode.Visible = false;
            txtCant.Location = new System.Drawing.Point( 662, 776 );
            lblCant.Location = new System.Drawing.Point( 568, 790 );
            dgvCodeList.Visible = false;
            btnRefresh.BackColor = Color.FromArgb( 60, 60, 60 );
            btnRefresh.ForeColor = Color.FromArgb( 224, 224, 224 );
            btnRefresh.Location = new System.Drawing.Point( 1100, 776 );
            btnRefresh.Text = "Seleccionar";
            btnRefresh.Enabled = false;
            dgvList.Size = new System.Drawing.Size( 1249, 662 );
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
            cleanTextFields();
            cleanTemp();
            refreshButtons();
        }


        private void cleanTextFields()
        {
            txtCode.Text = string.Empty;
            txtCant.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDetail.Text = string.Empty;
            txtSearchCode.Text = string.Empty;
            txtSearchProduct.Text = string.Empty;
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

            
            CodeForm codeForm = new CodeForm();

            if ( result.Equals( DialogResult.Yes ) )
            {
                codeForm.tempBool = true;
            }
            else
            {
                codeForm.tempBool = false;
            }

            DialogResult resp = codeForm.ShowDialog();

            if ( resp.Equals( DialogResult.OK ) ) fillCodeDgv();
        }


        private void dgvCodeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvCodeList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow row = dgvCodeList.SelectedRows[0];

                tempCodeId = Convert.ToInt64( row.Cells["CcodeId"].Value );
                string code = row.Cells["Ccode"].Value.ToString();

                txtCode.Text = code;
            }
        }


        private void dgvCodeList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvCodeList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow row = dgvCodeList.SelectedRows[0];

                long codeId = Convert.ToInt64(row.Cells["CcodeId"].Value);
                string code = row.Cells["Ccode"].Value.ToString();

                CodeForm codeForm = new CodeForm();
                codeForm.tempId = codeId;
                codeForm.txtCode.Text = code;
                codeForm.tempBool = false;

                DialogResult resp = codeForm.ShowDialog();

                if ( resp.Equals( DialogResult.OK) ) {
                    fillCodeDgv();
                    txtCode.Text = string.Empty;
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) )
            {
                product = new Logica.Models.Product();

                product.detail = txtDetail.Text.Trim();
                product.cant = Convert.ToInt32( txtCant.Text.Trim() );
                product.price = Convert.ToDecimal( txtPrice.Text.Trim() );
                if ( string.IsNullOrEmpty( tempCodeId.ToString() ) && tempCodeId <= 0 )
                {
                    product.code.codeId = 2;
                }
                else
                {
                    product.code.codeId = tempCodeId;
                }
                product.state.stateId = 1;

                string text = "Quieres agregar al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.addProduct();

                    if ( ok )
                    {
                        string detail = string.Format( "Agrego al producto: {0}", product.detail );

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

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


        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";

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

            return result.Equals( DialogResult.Yes ) ? true : false;
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
            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) && tempProductId > 0 )
            {
                product = new Logica.Models.Product();

                product.productId = tempProductId;
                product.detail = txtDetail.Text.Trim();
                product.cant = Convert.ToInt32( txtCant.Text.Trim() );
                product.price = Convert.ToDecimal( txtPrice.Text.Trim() );
                if ( string.IsNullOrEmpty( tempCodeId.ToString() ) && tempCodeId <= 0 )
                {
                    product.code.codeId = 2;
                }
                else
                {
                    product.code.codeId = tempCodeId;
                }
                product.state.stateId = 1;

                string text = "Quieres actualizar al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.updateProduct();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al producto: {0}", product.detail );

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if( tempProductId > 0 )
            {
                product = new Logica.Models.Product();

                product.productId = tempProductId;
                product.detail = txtDetail.Text.Trim();
                product.state.stateId = tempState;

                deleteMethod();
                
                string text = "Quieres" + deleteVector[0] + "al producto: {0} ?";

                bool msg = validateYesOrNot( text, product.detail );

                if ( msg )
                {
                    bool ok = product.deleteProduct();

                    if ( ok )
                    {
                        string detail = string.Format( deleteVector[1] + "al producto: {0}", product.detail );

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Producto fue" + deleteVector[2] + "correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        fillProductDgv();
                    }
                    else
                    {
                        MessageBox.Show( "No se" + deleteVector[3] + "el producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
            else
            {
                MessageBox.Show( "Selecciona el producto que desea" + deleteVector[0], ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
            } 

        }


        private void deleteMethod()
        {
            if ( tempState.Equals( 2 ) )
            {
                deleteVector[0] = " eliminar ";
                deleteVector[1] = " Elimino ";
                deleteVector[2] = " eliminado ";
                deleteVector[3] = " elimino ";
            }
            else
            {
                deleteVector[0] = " volver activar ";
                deleteVector[1] = " Has activado ";
                deleteVector[2] = " activado ";
                deleteVector[3] = " activo ";
            }
        }


        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            fillProductDgv();

            cbActive();
        }


        private int cbActive()
        {
            if ( cbActivos.Checked )
            {
                tempState = 2;
                return 1;
            }
            else
            {
                tempState = 1;
                return 2;
            }
        }


        private void btnRemoveCode_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
            tempCodeId = 2;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if ( btnRefresh.Text.Equals( "Refrescar" ) )
            {
                fillCodeDgv();
                fillProductDgv();
                cleanFields();
            }
            else
            {
                selectItem();
            }
        }


        private void selectItem()
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow row = dgvList.SelectedRows[0];

                string productId = row.Cells["CproductId"].Value.ToString().Trim();
                string code = row.Cells["CpCode"].Value.ToString().Trim();
                string item = row.Cells["CproductDetail"].Value.ToString().Trim();
                int quantity = Convert.ToInt32( row.Cells["Ccant"].Value );
                double price = Convert.ToDouble( row.Cells["Cprice"].Value );


                string validate = validateQuantity( item, quantity );

                if ( string.IsNullOrWhiteSpace( validate ) )
                {

                    if ( !validateRepeatedItem( productId, code ) )
                    {

                        DataRow drSale = Globals.StcMainForm.dtListItems.NewRow();

                        drSale["code"] = code;
                        drSale["productId"] = productId;
                        drSale["item"] = item;
                        drSale["price"] = price;
                        drSale["cant"] = Convert.ToInt32( txtCant.Text.Trim() );
                        drSale["quantity"] = quantity;

                        Globals.StcMainForm.dtListItems.Rows.Add( drSale );

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "Item repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
                else
                {
                    MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }


        private string validateQuantity( string item, int cant )
        {
            int quantity = quantityMethod();

            if ( cant.Equals( 0 ) )
            {
                return string.Format( "No hay {0} disponibles :(", item );
            }

            if ( quantity <= 0 )
            {
                return string.Format( "Seleccione de 1 unidada para arriba de: {0}", item );
            }

            if ( quantity > cant )
            {
                return string.Format( "Cantidad deseada es mayor a la disponible de: {0}", item );
            }

            return string.Empty;
        }


        private int quantityMethod()
        {
            if ( string.IsNullOrWhiteSpace( txtCant.Text.Trim() ) )
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32( txtCant.Text.Trim() );
            }
        }


        private bool validateRepeatedItem( string productId, string code )
        {
            bool codeRepeated = Globals.StcMainForm.dtListItems.Select().ToList().Exists( row => row["code"].ToString().Equals( code ) );

            bool idRepeated = Globals.StcMainForm.dtListItems.Select().ToList().Exists( row => row["productId"].ToString().Equals( productId ) );
        
            if ( string.IsNullOrWhiteSpace( code ) && idRepeated )
            {
                return true;
            }

            if ( codeRepeated && idRepeated )
            {
                return true;
            }

            return false;
        }


        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                if (btnRefresh.Text.Equals("Seleccionar"))
                {
                    btnRefresh.Enabled = true;
                    btnRefresh.BackColor = Color.FromArgb( 16, 123, 19 );
                    txtCant.Text = "1";
                }
                else
                {
                    selectCell();
                }
                
            }
        }


        private void selectCell()
        {
            DataGridViewRow row = dgvList.SelectedRows[0];

            tempProductId = Convert.ToInt64(row.Cells["CproductId"].Value);
            txtCode.Text = row.Cells["CpCode"].Value.ToString().Trim();
            txtDetail.Text = row.Cells["CproductDetail"].Value.ToString().Trim();
            txtCant.Text = row.Cells["Ccant"].Value.ToString().Trim();
            txtPrice.Text = row.Cells["Cprice"].Value.ToString().Trim();
            tempCodeId = Convert.ToInt64(row.Cells["CpCodeId"].Value);

            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            
        }

        
    }
}
