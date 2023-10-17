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
    public partial class MainForm : Form
    {
        public Logica.Models.Sale sale { get; set; }

        public DataTable dtListItems { get; set; }


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

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            InventoryForm inventory = new InventoryForm();

            inventory.showItems = false;

            DialogResult resp = inventory.ShowDialog();

            if ( resp.Equals( DialogResult.OK ))
            {
                MessageBox.Show("good",  ":)");
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
