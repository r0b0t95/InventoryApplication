using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class ClientsListForm : Form
    {
        Logica.Models.Client client;

        DataTable dtList { set; get; }

        private int tempState {  get; set; }


        public ClientsListForm()
        {
            InitializeComponent();

            client = new Logica.Models.Client();

            dtList = new DataTable();
        }


        // show the client register form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientsForm clientForm = new ClientsForm();

            DialogResult resp = clientForm.ShowDialog();

            if ( resp.Equals( DialogResult.OK ) ) fillDgv();
        }


        // exit the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // load data into the form
        private void ClientsListForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }


        // insert data into the data grid view
        public void fillDgv()
        {
            int active = cbActive();

            dtList = client.list( active, txtSearch.Text.Trim() );

            dgvList.DataSource = dtList;
        }


        // search specific characters into the data list
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearch.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearch.Text.Trim() ) )
            {
                fillDgv();
            }
        }


        // select a client 
        // show the client in the main form
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) ) 
            { 
                DataGridViewRow row = dgvList.SelectedRows[0];

                string clientId = Convert.ToString( row.Cells["CclientId"].Value );
                string clientName = Convert.ToString( row.Cells["CclientName"].Value );

                Globals.StcMainForm.txtClientId.Text = clientId.ToString();
                Globals.StcMainForm.txtClientName.Text = clientName.ToString();

                this.DialogResult = DialogResult.OK;
            }
        }


        // show the user modify form
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
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
                clientForm.tempState = tempState;

                DialogResult resp = clientForm.ShowDialog();

                if ( resp.Equals( DialogResult.OK ) ) fillDgv();
            }
        }


        // show active o inactive clients
        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            fillDgv();

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

       
    }
}
