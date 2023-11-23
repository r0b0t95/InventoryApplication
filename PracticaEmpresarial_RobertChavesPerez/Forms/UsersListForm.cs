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
    public partial class UsersListForm : Form
    {
        Logica.Models.User user;

        DataTable dtList { set; get; }

        private int tempState { set; get; }

        public UsersListForm()
        {
            InitializeComponent();

            user = new Logica.Models.User();

            dtList = new DataTable();
        }

        // exit the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // show the user register form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SignUpForm userForm = new SignUpForm();

            DialogResult resp = userForm.ShowDialog();

            if ( resp.Equals( DialogResult.OK ) ) fillDgv();
        }


        // show the user modify form
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow row = dgvList.SelectedRows[0];

                long userId = Convert.ToInt64( row.Cells["CuserId"].Value );
                string userName = row.Cells["CuserName"].Value.ToString();
                string userEmail = row.Cells["CuserEmail"].Value.ToString();
                string userRol = row.Cells["CrolName"].Value.ToString();

                SignUpForm userForm = new SignUpForm();
                userForm.tempId = userId;
                userForm.txtName.Text = userName.ToString();
                userForm.txtEmail.Text = userEmail.ToString();
                userForm.tempRol = userRol.ToString().Trim();
                userForm.tempState = tempState;

                DialogResult resp = userForm.ShowDialog();

                if ( resp.Equals( DialogResult.OK ) ) fillDgv();

            }

        }


        // load data into the form
        private void UsersListForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }


        // insert data into the data grid view
        public void fillDgv()
        {
            int active = cbActive();

            dtList = user.list( active, txtSearch.Text.Trim() );

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



        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            fillDgv();

            cbActive();
        }


        // show actives or inactives users
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
