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
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            user = new Logica.Models.User();

            user.name = txtName.Text.Trim();
            user.password = txtPassword.Text.Trim();

            if ( string.IsNullOrEmpty( validate ) )
            {

                int userId = user.loginUser();

                if ( userId > 0 )
                {
                    Globals.GlobalUser.userId = userId;

                    //TODO: insert all data into GlobalUser

                    cleanFields();
                   
                    new LoadingForm().Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show( "Nombre o contraseña incorrecto", ":(", MessageBoxButtons.OK );
                }

            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK );
            }
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

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {

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
            //contraseña
            if ( txtPassword.ForeColor == Color.FromArgb( 64, 64, 64 ) )
            {
                textPassword();
            }
        }

        private void textName()
        {
            txtName.Text = String.Empty;
            txtName.ForeColor = Color.Silver;
        }

        private void textPassword()
        {
            txtPassword.Text = String.Empty;
            txtPassword.ForeColor = Color.Silver;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            new SignUpForm().Show();
        }

        private string validateFields() 
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtName.Text ) || txtName.Text.Trim() == "Nombre o Correo" )
            {
                return string.Format(responce, "Nombre o Correo");
            }

            if( string.IsNullOrWhiteSpace( txtPassword.Text ) || txtPassword.Text.Trim() == "Contraseña" )
            {
                return string.Format( responce, "Contraseña" );
            }

            return string.Empty;
        }

        private void lblPolicies_Click(object sender, EventArgs e)
        {
            string message = "Hola usuario las politicas del software son \n" +
                             "para ingresar al programa tienes que ingresar \n" +
                             "solo por medio del login \n \n" +
                             "el programa tiene la base de datos local \n" +
                             "solo el administrador puede tener acceso a la \n" +
                             "base de datos \n \n" +
                             "actualizar el respaldo del inventario de hace de \n" +
                             "forma manual si el usuario lo olvida es responsabilidad \n" +
                             "del usuario \n \n \n" +
                             "Creado por Robert Chaves Perez v1 2023";

            MessageBox.Show( message, "Politicas", MessageBoxButtons.OK );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

    }
}
