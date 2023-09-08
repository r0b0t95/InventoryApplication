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
    public partial class ClientsForm : Form
    {
        private Logica.Models.Client client { get; set; }

        public ClientsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            client = new Logica.Models.Client();

            client.name = txtName.Text.Trim();
            client.email = txtEmail.Text.Trim();
            client.tel = Convert.ToInt32( txtTel.Text.Trim() );
            client.state.stateId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {
                bool msg = validateYesOrNot( client.name );

                if( msg )
                {
                    bool ok = client.addClient();

                    if( ok )
                    {
                        MessageBox.Show("Cliente agregado correctamente", ":)", MessageBoxButtons.OK);

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show("No se agrego el cliente", ":(", MessageBoxButtons.OK);
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

        private bool validateYesOrNot(string description)
        {
            string msg = string.Format( "Quieres agregar al cliente: {0} ?", description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
        }

        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTel.Text = string.Empty;
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit( e.KeyChar ) ) e.Handled = true;
        }
    }
}
