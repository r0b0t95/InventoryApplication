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
            ClientsForm clientForm = new ClientsForm();

            DialogResult resp = clientForm.ShowDialog();

            if ( resp == DialogResult.OK ) fillDgv();
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
            dtList = client.list( cbActivos.Checked, txtSearch.Text.Trim() );

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

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count == 1 )
            {
                DataGridViewRow row = dgvList.SelectedRows[0];

                long clientId = Convert.ToInt64( row.Cells["CclientId"].Value );
                string clientName = row.Cells["CclientName"].Value.ToString();
                string clientTel = row.Cells["CclientTel"].Value.ToString();
                string clientEmail = row.Cells["CclientEmail"].Value.ToString();

                ClientsForm clientForm = new ClientsForm();
                clientForm.tempId = clientId;
                clientForm.txtName.Text = clientName.ToString();
                clientForm.txtTel.Text = clientTel.ToString();
                clientForm.txtEmail.Text = clientEmail.ToString();

                DialogResult resp = clientForm.ShowDialog();

                if ( resp == DialogResult.OK ) fillDgv();

            }

        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

    }
}
