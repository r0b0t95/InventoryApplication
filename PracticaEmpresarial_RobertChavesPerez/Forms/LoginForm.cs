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
    public partial class LoginForm : Form
    {
        private Logica.Models.User user { get; set; }

        public LoginForm()
        {
            InitializeComponent();

            this.KeyDown += LoginForm_KeyDown;
        }


        // user login
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            
            string validate = validateFields();

            user = new Logica.Models.User();

            user.name = txtName.Text.Trim();
            user.password = txtPassword.Text.Trim();

            if ( string.IsNullOrEmpty( validate ) )
            {

                int[] lUser = user.loginUser();

                if ( lUser[0] > 0 )
                {
                    if ( lUser[1].Equals( 1 ) )
                    {
                        Globals.GlobalUser.userId = lUser[0];

                        Globals.GlobalUser.name = txtName.Text.Trim();

                        Globals.GlobalUser.rol.rolId = lUser[2];

                        cleanFields();

                        new LoadingForm().Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show( "Usuario desactivado", ":(", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    }
                }
                else
                {
                    MessageBox.Show( "Nombre o contraseña incorrecto", ":(", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }

            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            
            
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


        // show recovery form
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            new RecoverPassword().Show();
        }


        private void txtName_Click(object sender, EventArgs e)
        {
            if ( txtName.ForeColor == Color.FromArgb( 64, 64, 64 ) )
            {
                textName();
            }
        }


        private void txtPassword_Click(object sender, EventArgs e)
        {
            if ( txtPassword.ForeColor == Color.FromArgb( 64, 64, 64 ) )
            {
                textPassword();
            }
        }


        // change user name text field
        private void textName()
        {
            txtName.Text = String.Empty;
            txtName.ForeColor = Color.Silver;
        }


        // change user password text field
        private void textPassword()
        {
            txtPassword.Text = String.Empty;
            txtPassword.ForeColor = Color.Silver;
            txtPassword.UseSystemPasswordChar = true;
        }


        // validate empty text fields
        private string validateFields() 
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtName.Text ) || txtName.Text.Trim() == "Nombre de usuario" )
            {
                return string.Format(responce, "Nombre de usuario");
            }

            if( string.IsNullOrWhiteSpace( txtPassword.Text ) || txtPassword.Text.Trim() == "Contraseña" )
            {
                return string.Format( responce, "Contraseña" );
            }

            return string.Empty;
        }


        // show policies
        private void lblPolicies_Click(object sender, EventArgs e)
        {
            string message = "Hola usuario las politicas del software son \n" +
                             "para ingresar al programa tienes que ingresar \n" +
                             "solo por medio del login \n \n" +
                             "el programa tiene la base de datos local \n" +
                             "solo el administrador puede tener acceso a la \n" +
                             "base de datos \n \n" +
                             "actualizar el respaldo del inventario se hace de \n" +
                             "forma manual si el usuario lo olvida es responsabilidad \n" +
                             "del usuario \n \n" +
                             "el usuario administrador tiene mas privilegios en el \n" +
                             "usuario regular \n \n \n" +
                             "Creado por Robert Chaves Perez v1 2023";

            MessageBox.Show( message, "Politicas", MessageBoxButtons.OK );
        }


        // application exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // clean text fields
        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }


        //quick access 
        // Shift + Alt + Control + R
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Shift && e.Alt && e.Control && e.KeyCode == Keys.R ) 
            {
                Globals.GlobalUser.userId = 1;

                Globals.GlobalUser.name = "anonymous";

                Globals.GlobalUser.rol.rolId = 1;

                cleanFields();

                new LoadingForm().Show();

                this.Hide();
            }
        }

    }
}
