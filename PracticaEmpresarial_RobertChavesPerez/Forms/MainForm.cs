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

        public MainForm()
        {
            InitializeComponent();
        }

        private void logsItem_Click(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }

        private void inventoryItem_Click(object sender, EventArgs e)
        {
            Form inventory = new InventoryForm();

            this.Visible = false;

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

            DialogResult r = clientListForm.ShowDialog();

            if ( r == DialogResult.OK ) MessageBox.Show( "Cliente seleccionado", ":)", MessageBoxButtons.OK );
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


    }
}
