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

        private string tempEmail { get; set; }

        private string tempTel { get; set; }

        public int tempState { get; set; }

        private string[] deleteVector { get; set; }


        public ClientsForm()
        {
            InitializeComponent();

            log = new Logica.Models.Logg();

            deleteVector = new string[4];
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            client = new Logica.Models.Client();

            client.name = txtName.Text.Trim();
            client.email = txtEmail.Text.Trim();
            if ( !string.IsNullOrWhiteSpace( txtTel.Text.Trim() ) )
            {
                client.tel = Convert.ToInt64( txtTel.Text.Trim() );
            }
            client.state.stateId = 1;

            string validate = validateFields( client );

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

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Cliente agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el cliente", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        private string validateFields( Client client )
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtName.Text.Trim() ) )
            {
                return string.Format( responce, "nombre" );
            }

            if ( client.consultTel() && !txtTel.Text.Trim().Equals( tempTel ) &&
                !string.IsNullOrWhiteSpace( txtTel.Text.Trim() ) )
            {
                return string.Format( "El telefono {0} ya existe", txtTel.Text.Trim() );;
            }

            if ( client.consultEmail() && !txtEmail.Text.Trim().Equals( tempEmail ) &&
                !string.IsNullOrWhiteSpace( txtEmail.Text.Trim() ) )
            {
                return string.Format( "El correo {0} ya existe", txtEmail.Text.Trim() );
            }

            return string.Empty;
        }


        private bool validateYesOrNot( string text ,string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result.Equals( DialogResult.Yes ) ? true : false;
        }


        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTel.Text = string.Empty;
            tempState = 0;
        }


        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' ) e.Handled = true;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            client = new Logica.Models.Client();

            client.clientId = tempId;
            client.name = txtName.Text.Trim();
            client.email = txtEmail.Text.Trim();
            if( !string.IsNullOrWhiteSpace( txtTel.Text.Trim() ) )
            {
                client.tel = Convert.ToInt64( txtTel.Text.Trim() );
            }
            else
            {
                client.tel = 0;
            }
            string validate = validateFields( client );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar al cliente: {0} ?";

                bool msg = validateYesOrNot( text, client.name );

                if ( msg )
                {
                    bool ok = client.updateClient();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al cliente: {0}", client.name );

                        log.addLogEvent( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Cliente actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el cliente", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        private void ClientsForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }


        private void loadForm()
        {
            if ( this.tempId.Equals( 0 ) )
            {
                loadRegister();
            }
            else
            {
                loadModified();
            }
        }


        private void loadRegister()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            lblTitle.Text = "Registrar Cliente";
        }


        private void loadModified()
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblTitle.Text = "Modificar Cliente";
            fillTemporal();
        }


        private void fillTemporal()
        {
            tempEmail = txtEmail.Text.Trim();
            tempTel = txtTel.Text.Trim();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            client = new Logica.Models.Client();

            client.clientId = tempId;
            client.name = txtName.Text.Trim();
            client.state.stateId = tempState;

            deleteMethod();

            string text = "Quieres" + deleteVector[0] + "al cliente: {0} ?";

            bool msg = validateYesOrNot( text, client.name );

            if ( msg )
            {
                bool ok = client.deleteClient();

                if ( ok )
                {
                    string detail = string.Format( deleteVector[1] + "al cliente: {0}", client.name );

                    log.addLogEvent( detail, Globals.GlobalUser.userId );

                    MessageBox.Show( "Cliente fue" + deleteVector[2] + "correctamente", ":)", MessageBoxButtons.OK );

                    cleanFields();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show( "No se" + deleteVector[3] + "el cliente", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }

        }


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
