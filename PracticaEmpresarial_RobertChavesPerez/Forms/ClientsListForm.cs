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

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class ClientsListForm : Form
    {
        Logica.Models.Client client;

        DataTable dtList { set; get; }

        public ClientsListForm()
        {
            InitializeComponent();

            client = new Logica.Models.Client();

            dtList = new DataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ClientsForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientsListForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }

        public void fillDgv()
        {
            dtList = client.list( true, txtSearch.Text.Trim() );

            dgvList.DataSource = dtList;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearch.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearch.Text.Trim() ) )
            {
                fillDgv();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count == 1 ) 
            { 
                DataGridViewRow row = dgvList.SelectedRows[0];

                string clientId = Convert.ToString( row.Cells["CclientId"].Value );
                string clientName = Convert.ToString( row.Cells["CclientName"].Value );

                Globals.StcMainForm.txtClientId.Text = clientId.ToString();
                Globals.StcMainForm.txtClientName.Text = clientName.ToString();

                this.DialogResult = DialogResult.OK;
            }

        }

    }
}
