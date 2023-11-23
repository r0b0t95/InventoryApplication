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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class SignUpForm : Form
    {
        private Logica.Models.User user { get; set; }

        private Logica.Models.Logg log { get; set; }

        private Logica.Models.Rol rol { get; set; }

        public long tempId { get; set; }

        public string tempRol { get; set; }

        private string tempName { get; set; }

        private string tempEmail { get; set; }

        public int tempState { get; set; }

        private string[] deleteVector { get; set; }


        public SignUpForm()
        {
            InitializeComponent();

            rol = new Logica.Models.Rol();

            log = new Logica.Models.Logg();

            deleteVector = new string[4]; 
        }


        // show password
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


        // exit form 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // add user
        private void btnSave_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.name = txtName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPassword.Text.Trim();
            user.state.stateId = 1;
            user.rol.rolId = cbUsersType.SelectedIndex + 1;

            string validate = validateFields( user );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres agregar al usuario: {0} ?";

                bool msg = validateYesOrNot( text, user.name );

                if ( msg )
                {
                    bool ok = user.addUser();

                    if ( ok )
                    {
                        string detail = string.Format("Agrego al cliente: {0}", user.name);

                        log.addEventLog( detail, Globals.GlobalUser.userId ); 

                        MessageBox.Show( "Usuario agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el usuario", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        // validate empty texts fields
        // execute some databases querys
        private string validateFields( User user )
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtName.Text.Trim() ) )
            {
                return string.Format( responce, "nombre" );
            }

            if ( txtPassword.Text.Trim().Count() < 4 && lblTitle.Text.Equals( "Registrar Usuario" ) )
            {
                return string.Format(responce, "contraseña debe ser minimo de 4 caracteres");
            }

            if ( !cbUsersType.SelectedIndex.Equals( 0 ) && !cbUsersType.SelectedIndex.Equals( 1 ) )
            {
                return string.Format( responce, "debe seleccionar el rol del usuario" );
            }

            if ( user.consultName() && !txtName.Text.Trim().Equals( tempName ) )
            {
                return string.Format( "El nombre {0} ya existe", txtName.Text.Trim() );
            }

            if ( user.consultEmail() && !txtEmail.Text.Trim().Equals( tempEmail ) && 
                !string.IsNullOrWhiteSpace( txtEmail.Text.Trim() ) )
            {
                return string.Format( "El correo {0} ya existe", txtEmail.Text.Trim() );
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
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbUsersType.SelectedIndex = -1;
            tempState = 0;
        }


        // list all users roles
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


        // update user
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.userId = tempId;
            user.name = txtName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.rol.rolId = cbUsersType.SelectedIndex + 1;
        
            string validate = validateFields( user );

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

                        log.addEventLog( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Usuario actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el usuario", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        // execute loadForm method
        private void SignUpForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }


        // load register user or
        // load modify user
        private void loadForm()
        {
            fillUsersType();

            if ( this.tempId.Equals( 0 ) )
            {
                loadRegister();
            }
            else
            {
                loadModified();
            }
        }


        // execute when you selected the register user form
        private void loadRegister() 
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            lblTitle.Text = "Registrar Usuario";
            txtPassword.Enabled = true;
            cbShowPassword.Enabled = true;
            cbUsersType.SelectedIndex = -1;
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            cbShowPassword.Visible = true;
        }


        // execute when you selected the modify user form
        private void loadModified()
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblTitle.Text = "Modificar Usuario";
            txtPassword.Enabled = false;
            cbShowPassword.Enabled = false;
            int item = chooseRole(tempRol.ToString());
            cbUsersType.SelectedIndex = item;
            fillTemporal();
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            cbShowPassword.Visible = false;
        }


        // temporary attributes
        private void fillTemporal()
        {
            tempName = txtName.Text.Trim();
            tempEmail = txtEmail.Text.Trim();
        }


        private int chooseRole( string role )
        {
            return role.Equals( "Administrador" ) ? 0 : 1;
        }


        // delete user
        private void btnDelete_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.userId = tempId;
            user.name = txtName.Text.Trim();
            user.state.stateId = tempState;

            deleteMethod();

            string text = "Quieres" + deleteVector[0] + "al usuario: {0} ?";

            bool msg = validateYesOrNot( text, user.name );

            if ( msg )
            {
                bool ok = user.deleteUser();

                if ( ok )
                {
                    deleteMethod();

                    string detail = string.Format( deleteVector[1] + "al usuario: {0}", user.name );

                    log.addEventLog( detail, Globals.GlobalUser.userId );

                    MessageBox.Show( "Usuario fue" + deleteVector[2] + "correctamente", ":)", MessageBoxButtons.OK );

                    cleanFields();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show( "No se" + deleteVector[3] + "el usuario", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                }
            }
        }


        // load delete or active the client
        private void deleteMethod()
        {
            if ( tempState.Equals( 2 ) )
            {
                deleteVector[0] = " eliminar ";
                deleteVector[1] = "Elimino ";
                deleteVector[2] = " eliminado ";
                deleteVector[3] = " elimino ";
            }
            else
            {
                deleteVector[0] = " volver activar ";
                deleteVector[1] = "Has activado ";
                deleteVector[2] = " activado ";
                deleteVector[3] = " activo ";
            }
        }



    }
}
