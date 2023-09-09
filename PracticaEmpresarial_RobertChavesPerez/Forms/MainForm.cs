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

        private void clientsItem_Click(object sender, EventArgs e)
        {
            new ClientsForm().Show();
        }

        private void logsItem_Click(object sender, EventArgs e)
        {
            new LogsForm().Show();
        }

        private void suppliersItem_Click(object sender, EventArgs e)
        {
            new SuppliersListForm().Show();
        }

        private void inventoryItem_Click(object sender, EventArgs e)
        {
            new InventoryForm().Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
