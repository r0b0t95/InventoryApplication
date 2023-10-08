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
    public partial class CodeForm : Form
    {
        private Logica.Models.Code code { get; set; }

        private Logica.Models.Logg log { get; set; }

        public long tempId { get; set; }

        private string tempCode { get; set; }

        public CodeForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            code = new Logica.Models.Code();

            code.code = txtCode.Text.Trim();

            string validate = validateFields( code );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres agregar al codigo: {0} ?";

                bool msg = validateYesOrNot( text, code.code );

                if ( msg )
                {
                    bool ok = code.addCode();

                    if (ok)
                    {
                        string detail = string.Format( "Agrego al codigo: {0}", code.code );

                        addLogEvent( detail );

                        MessageBox.Show( "Codigo agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
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

        private void CodeForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void loadForm()
        {
            if (this.tempId.Equals(0))
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                lblTitle.Text = "Registrar Codigo";
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                lblTitle.Text = "Modificar Codigo";
                fillTemporal();
            }
        }

        private void fillTemporal()
        {
            tempCode = txtCode.Text.Trim();
        }

        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
        }

        private void cleanFields()
        {
            txtCode.Text = string.Empty;
        }

        private void addLogEvent(string detail)
        {
            log = new Logica.Models.Logg();
            log.user.userId = Globals.GlobalUser.userId;
            log.logDetail = detail;
            log.logDate = DateTime.Now;

            log.addLog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            code = new Logica.Models.Code();

            code.codeId = tempId;
            code.code = txtCode.Text.Trim();

            string validate = validateFields( code );

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar al codigo: {0} ?";

                bool msg = validateYesOrNot( text, code.code );

                if ( msg )
                {
                    bool ok = code.updateCode();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al codigo: {0}", code.code );

                        addLogEvent( detail );

                        MessageBox.Show( "Codigo actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
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
         
        private string validateFields( Code code )
        {
            string responce = "El campo {0} esta vacio";

            if ( string.IsNullOrWhiteSpace( txtCode.Text.Trim() ) )
            {
                return string.Format( responce, "codigo" );
            }

            if ( code.consultCode() && !txtCode.Text.Trim().Trim().Equals( tempCode ) )
            {
                return string.Format( "El codigo {0} ya existe", txtCode.Text.Trim() ); ;
            }

            return string.Empty;
        }


    }
}
