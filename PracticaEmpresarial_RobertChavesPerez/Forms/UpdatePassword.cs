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
using System.Xml.Linq;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class UpdatePassword : Form
    {
        private Logica.Models.User user;

        private Logica.Models.Logg log { get; set; }

        public UpdatePassword()
        {
            InitializeComponent();

            log = new Logica.Models.Logg();
        }


        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbShowPassword.Checked )
            {
                txtCurrentPass.UseSystemPasswordChar = false;
                txtNewPass.UseSystemPasswordChar = false;
                txtConNewPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtCurrentPass.UseSystemPasswordChar = true;
                txtNewPass.UseSystemPasswordChar = true;
                txtConNewPass.UseSystemPasswordChar = true;
            }
        }


        // exit to the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // validate empty fields
        // validate user credentials
        private string validateFields( User user )
        {
            string responce = "El campo {0} esta vacio";

            int[] lUser = user.loginUser();

            if ( string.IsNullOrWhiteSpace( txtCurrentPass.Text ) )
            {
                return string.Format( responce, "Contraseña Actual");
            }

            if ( string.IsNullOrWhiteSpace( txtNewPass.Text ) )
            {
                return string.Format( responce, "Nueva Contraseña" );
            }
             
            if ( string.IsNullOrWhiteSpace( txtConNewPass.Text ) )
            {
                return string.Format( responce, "Confirmacion Nueva Contraseña" );
            }

            if ( txtNewPass.Text.Trim().Count() < 4 )
            {
                return "contraseña nueva debe ser minimo de 4 caracteres";
            }

            if ( txtCurrentPass.Text.Trim().Equals( txtNewPass.Text.Trim() ) )
            {
                return "La nueva contraseña es igual a la actual";
            }

            if ( lUser[0] <= 0 )
            {
                return "Contraseña actual es incorrecta";
            }

            if ( !txtNewPass.Text.Trim().Equals( txtConNewPass.Text.Trim() ) )
            {
                return "La Nueva Contraseña y su confirmacion son diferentes";
            }

            return string.Empty;
        }


        // ask the user if want to continue by a message
        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result.Equals( DialogResult.Yes ) ? true : false;
        }


        // clean the text fields
        private void cleanFields()
        {
            txtCurrentPass.Text = string.Empty;
            txtNewPass.Text = string.Empty;
            txtConNewPass.Text= string.Empty;
        }


        // update password button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            user = new Logica.Models.User();

            user.userId = Globals.GlobalUser.userId;
            user.password = txtCurrentPass.Text.Trim();
            user.name = Globals.GlobalUser.name;

            string validate = validateFields( user );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar la contraseña: {0} ?";

                bool msg = validateYesOrNot( text, user.name );

                if ( msg )
                {
                    user.password = txtNewPass.Text.Trim();

                    bool ok = user.updatePassword();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo su propia contraseña: {0}", user.name );

                        log.addEventLog( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Contraseña actualizada correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo la contraseña", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

       

    }
}
