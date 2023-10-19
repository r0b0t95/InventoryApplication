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
        public Logica.Models.Sale sale { get; set; }

        public DataTable dtListItems { get; set; }

        private int tempQuantity { get; set; }

        private string tempProduct { get; set; }

        public MainForm()
        {
            InitializeComponent();

            sale = new Logica.Models.Sale();

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
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }


        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
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
            double discount = 0;
            double subTotal = 0;
            double total = 0;
            double IVA = 1;
            double tax = 0;
            int quantity = 0;

            if ( dtListItems.Rows.Count > 0 )
            {
                foreach ( DataRow item in dtListItems.Rows )
                {
                    quantity = Convert.ToInt32( item["cant"] );
                    subTotal += Convert.ToDouble( item["price"] );

                    subTotal *= quantity;
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

        private double discountMethod()
        {
            if (string.IsNullOrWhiteSpace( txtDiscount.Text.Trim() ) )
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble( txtDiscount.Text.Trim() );
            }
        }

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
                 }
             }
             else
             {
                 MessageBox.Show( "Debes seleccionar una fila de un producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
             }
            
        }


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

                tempProduct = Convert.ToString( dtListItems.Rows[dgvr.Index][2] );

                txtCant.Text = Convert.ToString( dtListItems.Rows[dgvr.Index][3] );

                tempQuantity = Convert.ToInt32( dtListItems.Rows[dgvr.Index][5] );
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
        
                dtListItems.Rows.RemoveAt( dgvr.Index );

                dgvList.DataSource = dtListItems;

                dgvList.ClearSelection();

                calculateAmount();

                dontShowQuantity();
            }
            else
            {
                MessageBox.Show( "Debes seleccionar una fila de un producto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            sale = new Logica.Models.Sale();

            /*
        public long saleId { get; set; }
        public string detail { get; set; }
        public DateTime date { get; set; }
        public double subTotal { get; set; }
        public double discount { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
        public User user { get; set; }
        public Client client { get; set; }
        public State state { get; set; }
             */

            /*
            sale.detail = "";
            sale.date = DateTime.Now;

            user.name = txtName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPassword.Text.Trim();
            user.state.stateId = 1;
            user.rol.rolId = cbUsersType.SelectedIndex + 1;

            string validate = validateFields(user);

            if (string.IsNullOrEmpty(validate))
            {
                string text = "Quieres agregar al usuario: {0} ?";

                bool msg = validateYesOrNot(text, user.name);

                if (msg)
                {
                    bool ok = user.addUser();

                    if (ok)
                    {
                        string detail = string.Format("Agrego al cliente: {0}", user.name);

                        addLogEvent(detail);

                        MessageBox.Show("Usuario agregado correctamente", ":)", MessageBoxButtons.OK);

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No se agrego el usuario", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
            else
            {
                MessageBox.Show(validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            */
        }

        















        /*
        private string validateFields(User user)
        {
            
            string responce = "El campo {0} esta vacio";

            if ( txt )
            {
                return string.Format(responce, "nombre");
            }

            return string.Empty;
            
        }
        */




    }
}
