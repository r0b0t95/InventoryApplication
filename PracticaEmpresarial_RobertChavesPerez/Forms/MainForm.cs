﻿using Logica;
using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class MainForm : Form
    {
        private Logica.Models.Sale sale { get; set; }

        private Logica.Models.Inventory inventory { get; set; }

        private Logica.Models.Product product { get; set; }

        public DataTable dtListItems { get; set; }

        private int tempQuantity { get; set; }

        private string tempProduct { get; set; }

        public MainForm()
        {
            InitializeComponent();

            sale = new Logica.Models.Sale();

            product = new Logica.Models.Product();

            dtListItems = new DataTable();
        }


        // show logs form
        private void logsItem_Click(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }


        // select row product (item)
        private void inventoryItem_Click(object sender, EventArgs e)
        {
            InventoryForm inventory = new InventoryForm();

            this.Visible = false;

            inventory.showItems = true;
            inventory.ShowDialog();

            this.Visible = true;
        }


        // close system
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // execute loadData and privileges methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();

            privileges();
        }


        // insert columns and rows into the dtListItem data table
        private void loadData()
        {
            dtListItems = sale.billDetailsScheme();

            txtUser.Text = Globals.GlobalUser.name.ToString();
        }


        // users privileges 
        private void privileges()
        {
            long rol = Globals.GlobalUser.rol.rolId;

            if ( rol.Equals( 2 ) )
            {
                logsItem.Visible = false;
                usersItem.Visible = false;
            }
            else
            {
                logsItem.Visible = true;
                usersItem.Visible = true;
            }
        }


        // show logs form
        private void logsItem_Click_1(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }


        // show users form
        private void usersItem_Click(object sender, EventArgs e)
        {
            new UsersListForm().Show();
        }


        // show recovery password form
        private void changePasswordItem_Click(object sender, EventArgs e)
        {
            new UpdatePassword().Show();
        }


        // only allow numbers in the cant (quantity) text field
        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }


        // only allow numbers in the discount text field
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }


        // insert a item into sale data grid view
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


        // calculate discount, subtotal, total
        private void calculateAmount()
        {
            double discount = 0;
            double subTotal = 0;
            double price = 0;
            double total = 0;
            double IVA = 1;
            double tax = 0;
            int quantity = 0;

            if ( dtListItems.Rows.Count > 0 )
            {
                foreach ( DataRow item in dtListItems.Rows )
                {
                    quantity = Convert.ToInt32( item["cant"] );
                    price = Convert.ToDouble( item["price"] );

                    subTotal += quantity * price;
                }
            }


            discount = discountMethod();


            if ( cbIVA.Checked ) IVA = 1.13;

            total = ( subTotal * IVA ) - discount;

            if ( cbIVA.Checked )
            {
                tax = ( subTotal ) * 0.13;
            }
            else
            {
                tax = 0;
            }

            txtTax.Text = tax.ToString();
            txtSubTotal.Text = subTotal.ToString();
            txtTotal.Text = total.ToString();
        }


        // assign discount to the sale
        private double discountMethod()
        {
            if ( string.IsNullOrWhiteSpace( txtDiscount.Text.Trim() ) )
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble( txtDiscount.Text.Trim() );
            }
        }


        // show client form
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


        // update product quantity
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                string validate = quantity();

                if ( string.IsNullOrEmpty( validate ) )
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
                    MessageBox.Show( validate, ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    txtCant.Text = "1";
                }
            }
            else
            {
                MessageBox.Show( "Debes seleccionar una fila de un producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
        }


        // validate product quantity
        private string quantity()
        {
            int quantity = Convert.ToInt32( txtCant.Text.Trim() );

            if ( quantity <= 0 )
            {
                return "Cantidad debe ser mayor a 0";
            }

            if ( quantity > tempQuantity )
            {
                return string.Format( "Cantidad deseada es mayor a la disponible de: {0}", tempProduct );
            }

            return string.Empty;
        }


        // allow or deny IVA
        private void cbIVA_CheckedChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }


        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }


        // select a product (item)
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow dgvr = dgvList.SelectedRows[0];

                int dgvIndex = dgvr.Index;

                tempProduct = Convert.ToString( dtListItems.Rows[dgvr.Index][2] );

                txtCant.Text = Convert.ToString( dtListItems.Rows[dgvr.Index][3] );

                tempQuantity = Convert.ToInt32( dtListItems.Rows[dgvr.Index][5] );
            }

            showQuantity();
        }


        // show product quantity
        private void showQuantity()
        {
            lblCant.Visible = true;
            txtCant.Visible = true;
        }


        // don't show product quantity
        private void dontShowQuantity()
        {
            lblCant.Visible = false;
            txtCant.Visible = false;
        }


        // remove a product (item) from sale data grid view
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


        // create a sale
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) )
            {
                sale = new Sale();
                
                sale.date = DateTime.Now;
                sale.subTotal = Convert.ToDecimal( txtSubTotal.Text.Trim() );
                sale.discount = Convert.ToDecimal( discountMethod() );
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
                        string ticketText = "Ocupas un Ticket de compra ?";

                        bool ticket = validateYesOrNot( ticketText, Globals.GlobalUser.name );

                        if ( ticket )
                        {
                            createTicket( sale );
                        }

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


        // create a ticket
        private void createTicket( Sale sale )
        {
            Report report = new Report();

            report.Show();

            CrystalReport cr = new CrystalReport();

            DataTable dt = sale.ticket();

            cr.SetDataSource(dt);

            report.crystalReportV1.ReportSource = cr;

            report.crystalReportV1.Refresh();
        }


        // process create sale
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


        // validate empty fields
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


        // validate if user wants to continue
        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result.Equals( DialogResult.Yes ) ? true : false;
        }


        // clean text fields
        private void cleanFields()
        {
            txtSubTotal.Text = "0";
            txtTotal.Text = "0";
            txtTax.Text = "0";
            txtDiscount.Text = "0";
            txtCant.Text = "1";
            txtClientId.Text = string.Empty;
            txtClientName.Text = string.Empty;
            dtListItems.Clear();
            dgvList.DataSource = dtListItems;
            dgvList.ClearSelection();
        }


        // reset the main form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleanFields();
        }


        // create a ticket reference the last sale
        private void ticketItem_Click(object sender, EventArgs e)
        {
            sale = new Sale();
            sale.saleId = 0;

            createTicket( sale );
        }


        // show users form
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form clientListForm = new ClientsListForm();

            clientListForm.ShowDialog();
        }


        // create a database backup
        private void backUpItem_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();

            string path = @"C:\Respaldo Base Datos Inventario";

            try
            {
                if ( !Directory.Exists( path ) )
                {
                    Directory.CreateDirectory( path );
                }

                conn.backupDataBase();
                MessageBox.Show( "Respaldado de base datos creado con exito", ":)", MessageBoxButtons.OK );

            }
            catch ( Exception )
            {
                MessageBox.Show( "Error al crear respaldado de base datos", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        // show the database backup path
        private void restoreItem_Click(object sender, EventArgs e)
        {
            string msg = "el archivo InventoryDB.bak se encuentra en el disco C:" +
                "en la ruta -> C:\\Respaldo Base Datos Inventario\\InventoryDB.bak";

            MessageBox.Show( msg, ":)", MessageBoxButtons.OK );
        }


        // show sales form
        private void sellsItem_Click(object sender, EventArgs e)
        {
            new SalesListForm().Show();
        }


    }
}
