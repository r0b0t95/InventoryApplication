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

        private Logica.Models.Logg log { get; set; }

        public long tempId { get; set; }

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
            client.tel = Convert.ToInt64( txtTel.Text.Trim() );
            client.state.stateId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres agregar al cliente: {0} ?";

                bool msg = validateYesOrNot( text ,client.name );

                if( msg )
                {
                    bool ok = client.addClient();

                    if( ok )
                    {
                        string detail = string.Format( "Agrego al cliente: {0}", client.name );

                        addLogEvent( detail );

                        MessageBox.Show( "Cliente agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el cliente", ":(", MessageBoxButtons.OK );
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

        private bool validateYesOrNot( string text ,string description )
        {
            string msg = string.Format( text, description );

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
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }

        private void addLogEvent( string detail )
        {
            log = new Logica.Models.Logg();
            log.user.userId = Globals.GlobalUser.userId;
            log.logDetail = detail;
            log.logDate = DateTime.Now;

            log.addLog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            client = new Logica.Models.Client();

            client.clientId = tempId;
            client.name = txtName.Text.Trim();
            client.email = txtEmail.Text.Trim();
            client.tel = Convert.ToInt64( txtTel.Text.Trim() );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar al cliente: {0} ?";

                bool msg = validateYesOrNot( text, client.name );

                if (msg)
                {
                    bool ok = client.updateClient();

                    if (ok)
                    {
                        string detail = string.Format( "Actualizo al cliente: {0}", client.name );

                        addLogEvent( detail );

                        MessageBox.Show( "Cliente actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el cliente", ":(", MessageBoxButtons.OK );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK );
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void loadForm()
        {
            if ( this.id.Equals( 0 ) )
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }

    }
}
