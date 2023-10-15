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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";


            user = new Logica.Models.User();

            user.name = Globals.GlobalUser.name;
            user.password = txtCurrentPass.Text.Trim();
            user.state.stateId = 1;

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

            if ( lUser[0] <= 0 )
            {
                return "Contraseña actual es incorrecta";
            }

            if ( !txtNewPass.Text.Trim().Equals( txtConNewPass.Text.Trim() ) )
            {
                return string.Format( responce, "La Nueva Contraseña y su confirmacion son diferentes" );
            }

            return string.Empty;
        }


        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result == DialogResult.Yes ? true : false;
        }

        private void cleanFields()
        {
            txtCurrentPass.Text = string.Empty;
            txtNewPass.Text = string.Empty;
            txtConNewPass.Text= string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            user = new Logica.Models.User();

            user.userId = Globals.GlobalUser.userId;
            user.password = txtNewPass.Text;
            string name = Globals.GlobalUser.name;

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar la contraseña: {0} ?";

                bool msg = validateYesOrNot( text, name );

                if ( msg )
                {
                    bool ok = user.updatePassword();

                    if (ok)
                    {
                        string detail = string.Format( "Actualizo su propia contraseña: {0}", name );

                        addLogEvent(detail);

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
