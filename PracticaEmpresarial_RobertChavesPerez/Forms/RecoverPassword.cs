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
    public partial class RecoverPassword : Form
    {
        private Logica.Models.User user;


        public RecoverPassword()
        {
            InitializeComponent();
        }


        // exit form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // recover user password
        private void btnRecoveryPassword_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.name = txtUserName.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPass.Text.Trim();

            string validate = validateFields();

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Olvidaste la contraseña: {0} ?";

                bool msg = validateYesOrNot( text, user.name );

                if ( msg )
                {
                    string ok = user.recoveryPassword();

                    if ( !string.IsNullOrEmpty( ok ) )
                    {
                        string detail = string.Format( "Su contraseña es: {0}", ok );

                        cleanFields();

                        MessageBox.Show( detail, ":)", MessageBoxButtons.OK );
                    }
                    else
                    {
                        MessageBox.Show( "Credenciales incorrectas intente", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        // clean text fields
        private void cleanFields()
        {
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPass.Text = string.Empty;
        }


        // validate empty text fields
        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtUserName.Text.Trim() ) )
            {
                return string.Format( responce, "Nombre de usuario" );
            }

            if ( string.IsNullOrWhiteSpace( txtPass.Text.Trim() ) && txtPass.Text.Trim().Count() < 5 )
            {
                string msg = "Debe tener minimo 4 caracteres \n" +
                            "la aproximacion de la contraseña";

                return msg;
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


        // show current and new passwords
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbShowPassword.Checked )
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }


    }
}
