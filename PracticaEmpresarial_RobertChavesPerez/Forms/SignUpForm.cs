﻿using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class SignUpForm : Form
    {
        private Logica.Models.User user { get; set; }

        private Logica.Models.Logg log { get; set; }

        private Logica.Models.Rol rol { get; set; }

        public long tempId { get; set; }

        public string tempRol { get; set; }

        public SignUpForm()
        {
            InitializeComponent();

            rol = new Logica.Models.Rol();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbShowPassword.Checked )
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            user = new Logica.Models.User();

            user.name = txtName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPassword.Text.Trim();
            user.state.stateId = 1;
            user.rol.rolId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres agregar al usuario: {0} ?";

                bool msg = validateYesOrNot( text, user.name );

                if ( msg )
                {
                    bool ok = user.addUser();

                    if ( ok )
                    {
                        MessageBox.Show( "Usuario agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el usuario", ":(", MessageBoxButtons.OK );
                    }

                }

            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK );
            }
        }

        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtName.Text ) )
            {
                return string.Format( responce, "nombre" );
            }

            return string.Empty;
        }


        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
        }

        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbUsersType.SelectedIndex = -1;
        }

        public void fillUsersType()
        {
            DataTable dtList = new DataTable();

            dtList = rol.list();

            if ( dtList != null && dtList.Rows.Count > 0)
            {
                cbUsersType.ValueMember = "rolId";
                cbUsersType.DisplayMember = "rolName";
                cbUsersType.DataSource = dtList;
                cbUsersType.SelectedIndex = -1;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            user = new Logica.Models.User();

            user.userId = tempId;
            user.name = txtName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.rol.rolId = Convert.ToInt16( cbUsersType.SelectedValue );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar al usuario: {0} ?";

                bool msg = validateYesOrNot( text, user.name );

                if ( msg )
                {
                    bool ok = user.updateUser();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al usuario: {0}", user.name );

                        addLogEvent( detail );

                        MessageBox.Show( "Usuario actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el usuario", ":(", MessageBoxButtons.OK );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK );
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void loadForm()
        {
            fillUsersType();

            if ( this.tempId.Equals( 0 ) )
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblTitle.Text = "Registrar Usuario";
                txtPassword.Enabled = true;
                cbShowPassword.Enabled = true;
                cbUsersType.SelectedIndex = -1;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblTitle.Text = "Modificar Usuario";
                txtPassword.Enabled = false;
                cbShowPassword.Enabled = false;
                int item = chooseRole( tempRol.ToString() );
                cbUsersType.SelectedIndex = item;
            }
        }

        private int chooseRole( string role )
        {
            return role.Equals( "Administrador" ) ? 0 : 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.userId = tempId;
            user.name = txtName.Text.Trim();
            user.state.stateId = 2;

            string text = "Quieres eliminar al usuario: {0} ?";

            bool msg = validateYesOrNot( text, user.name );

            if ( msg )
            {
                bool ok = user.deleteUser();

                if ( ok )
                {
                    string detail = string.Format( "Elimino al usuario: {0}", user.name );

                    addLogEvent( detail );

                    MessageBox.Show( "Usuario fue eliminado correctamente", ":)", MessageBoxButtons.OK );

                    cleanFields();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show( "No se elimino el usuario", ":(", MessageBoxButtons.OK );
                }
            }
        }

        private void addLogEvent( string detail )
        {
            log = new Logica.Models.Logg();
            log.user.userId = Globals.GlobalUser.userId;
            log.logDetail = detail;
            log.logDate = DateTime.Now;

            log.addLog();
        }




    }
}
