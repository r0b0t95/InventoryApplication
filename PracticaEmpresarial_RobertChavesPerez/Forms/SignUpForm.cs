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
    public partial class SignUpForm : Form
    {
        private Logica.Models.User user { get; set; }

        public SignUpForm()
        {
            InitializeComponent();
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

            user.Name = txtName.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            user.userState.stateId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {

                bool msg = validateYesOrNot( user.Name );

                if (msg )
                {
                    bool ok = user.addUser();

                    if ( ok )
                    {
                        MessageBox.Show("Usuario agregado correctamente", ":)", MessageBoxButtons.OK);

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show("No se agrego el usuario", ":(", MessageBoxButtons.OK);
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

        private bool validateYesOrNot( string description )
        {
            string msg = string.Format( "Quieres agregar al usuario: {0} ?", description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
        }

        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

    }
}
