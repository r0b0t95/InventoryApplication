using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class MainForm : Form
    {
        private Logica.Models.Sale sale { get; set; }

        private Logica.Models.Inventory inventory { get; set; }

        private Logica.Models.Product product { get; set; }

        private Logica.Models.Logg log { get; set; }

        public DataTable dtListItems { get; set; }

        private int tempQuantity { get; set; }

        private string tempProduct { get; set; }

        public MainForm()
        {
            InitializeComponent();

            sale = new Logica.Models.Sale();

            product = new Logica.Models.Product();

            log = new Logica.Models.Logg();

            dtListItems = new DataTable();
        }

        private void logsItem_Click(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }


        private void inventoryItem_Click(object sender, EventArgs e)
        {
            InventoryForm inventory = new InventoryForm();

            this.Visible = false;

            inventory.showItems = true;
            inventory.ShowDialog();

            this.Visible = true;
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
        }


        private void loadData()
        {
            dtListItems = sale.billDetailsScheme();

            txtUser.Text = Globals.GlobalUser.name.ToString();
        }


        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            Form clientListForm = new ClientsListForm();

            clientListForm.ShowDialog();
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UsersListForm().Show();
        }


        private void logsItem_Click_1(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }


        private void usersItem_Click(object sender, EventArgs e)
        {
            new UsersListForm().Show();
        }


        private void changePasswordItem_Click(object sender, EventArgs e)
        {
            new UpdatePassword().Show();
        }


        private void clearFields()
        {
            txtSubTotal.Text = "0";
            txtDiscount.Text = "0";
            txtCant.Text = "0";
            txtTotal.Text = "0";
            dgvList.DataSource = dtListItems;
            btnAdd.Enabled = false;
        }


        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
        }


        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            dontShowQuantity();

            InventoryForm inventory = new InventoryForm();

            inventory.showItems = false;

            DialogResult resp = inventory.ShowDialog();

            if ( resp.Equals( DialogResult.OK ) )
            {
                dgvList.DataSource = dtListItems;

                dgvList.ClearSelection();

                calculateAmount();
            }
        }


        private void calculateAmount()
        {
            decimal discount = 0;
            decimal subTotal = 0;
            decimal total = 0;
            decimal IVA = 1;
            decimal tax = 0;
            int quantity = 0;

            if ( dtListItems.Rows.Count > 0 )
            {
                foreach ( DataRow item in dtListItems.Rows )
                {
                    quantity = Convert.ToInt32( item["cant"] );
                    subTotal += Convert.ToDecimal( item["price"] );

                    subTotal *= quantity;
                }
            }


            discount = discountMethod();


            if ( cbIVA.Checked ) IVA = 1.13M;

            total = ( subTotal * IVA ) - discount;

            if ( cbIVA.Checked )
            {
                tax = ( subTotal ) * 0.13M;
            }
            else
            {
                tax = 0;
            }

            txtTax.Text = tax.ToString();
            txtSubTotal.Text = subTotal.ToString();
            txtTotal.Text = total.ToString();
        }


        private decimal discountMethod()
        {
            if ( string.IsNullOrWhiteSpace( txtDiscount.Text.Trim() ) )
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal( txtDiscount.Text.Trim() );
            }
        }


        private long clientSelected()
        {
            if ( !string.IsNullOrWhiteSpace( txtClientId.Text.Trim() ) )
            {
                return Convert.ToInt64( txtClientId.Text.Trim() );
            }
            else
            {
                return 1;
            }
        }


        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            if (dgvList.SelectedRows.Count.Equals(1))
            {
                string validate = quantity();

                if (string.IsNullOrEmpty(validate))
                {
                    DataGridViewRow dgvr = dgvList.SelectedRows[0];

                    int dgvIndex = dgvr.Index;

                    dtListItems.Rows[dgvr.Index][3] = txtCant.Text.Trim();

                    dgvList.DataSource = dtListItems;

                    dgvList.ClearSelection();

                    calculateAmount();

                    dontShowQuantity();
                }
                else
                {
                    MessageBox.Show(validate, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila de un producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private string quantity()
        {
            int quantity = Convert.ToInt32(txtCant.Text.Trim());

            if (quantity <= 0)
            {
                return "Cantidad debe ser mayor a 0";
            }

            if (quantity > tempQuantity)
            {
                return string.Format("Cantidad deseada es mayor a la disponible de: {0}", tempProduct);
            }

            return string.Empty;
        }


        private void cbIVA_CheckedChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }


        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }


        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow dgvr = dgvList.SelectedRows[0];

                int dgvIndex = dgvr.Index;

                tempProduct = Convert.ToString(dtListItems.Rows[dgvr.Index][2]);

                txtCant.Text = Convert.ToString(dtListItems.Rows[dgvr.Index][3]);

                tempQuantity = Convert.ToInt32(dtListItems.Rows[dgvr.Index][5]);
            }

            showQuantity();
        }


        private void showQuantity()
        {
            lblCant.Visible = true;
            txtCant.Visible = true;
        }


        private void dontShowQuantity()
        {
            lblCant.Visible = false;
            txtCant.Visible = false;
        }


        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow dgvr = dgvList.SelectedRows[0];

                int dgvIndex = dgvr.Index;

                dtListItems.Rows.RemoveAt(dgvr.Index);

                dgvList.DataSource = dtListItems;

                dgvList.ClearSelection();

                calculateAmount();

                dontShowQuantity();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila de un producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) )
            {
                sale = new Sale();
                
                sale.date = DateTime.Now;
                sale.subTotal = Convert.ToDecimal( txtSubTotal.Text.Trim() );
                sale.discount = discountMethod();
                sale.tax = Convert.ToDecimal( txtTax.Text.Trim() );
                sale.total = Convert.ToDecimal( txtTotal.Text.Trim() );
                sale.user.userId = Globals.GlobalUser.userId;
                sale.client.clientId = clientSelected();
                sale.state.stateId = 1;
               

                string text = "Quieres hacer la venta {0} ?";

                bool msg = validateYesOrNot( text, Globals.GlobalUser.name );

                if ( msg )
                {
                    sale.detail = saleProcess( sale );

                    int ok = sale.addSale();

                    if ( ok > 0 )
                    {
                        string detail = string.Format( "El usuario: {0} hizo una venta", Globals.GlobalUser.name );

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Venta se realizo correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show( "No se realizo la venta", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        private List<Inventory> saleProcess( Sale sale )
        {
            int cant = 0;
            int quantity = 0;

            foreach( DataRow item in dtListItems.Rows )
            {
                inventory = new Logica.Models.Inventory();

                inventory.product = product.productId = Convert.ToInt64( item["productId"] );
                quantity = Convert.ToInt32( item["quantity"] );
                inventory.quantity = cant = Convert.ToInt32( item["cant"] );

                product.cant = ( quantity - cant );
                inventory.price = Convert.ToDecimal( item["price"] );

                product.updateQuantity();

                sale.detail.Add( inventory );
            }

            return sale.detail;
        }


        private string validateFields()
        {
            double total = Convert.ToDouble( txtTotal.Text.Trim() );

            if ( dtListItems.Rows.Count <= 0 )
            {
                return "No hay productos seleccionados";
            }

            if ( total < 0 )
            {
                return "El total no puede ser menor a 0";
            }

            return string.Empty;
        }


        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result.Equals( DialogResult.Yes ) ? true : false;
        }


        private void cleanFields()
        {
            txtSubTotal.Text = "0";
            txtTotal.Text = "0";
            txtTax.Text = "0";
            txtCant.Text = "1";
            dtListItems.Clear();
            dgvList.DataSource = dtListItems;
            dgvList.ClearSelection();
        }


    }
}
