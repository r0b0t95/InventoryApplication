﻿using Logica.Models;
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

        public bool tempBool { get; set; }


        public CodeForm()
        {
            InitializeComponent();

            log = new Logica.Models.Logg();
        }


        // exit the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        // add code
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

                        log.addEventLog( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Codigo agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        if ( !tempBool )
                        {
                            this.DialogResult = DialogResult.OK;
                        }
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


        // execute loadForm method
        private void CodeForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }


        // evaluate if the user
        // load the form modify or register
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


        // execute when you add a code
        private void loadRegister()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            lblTitle.Text = "Registrar Codigo";
        }


        // execute when you modify a code
        private void loadModified()
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lblTitle.Text = "Modificar Codigo";
            fillTemporal();
        }


        private void fillTemporal()
        {
            tempCode = txtCode.Text.Trim();
        }


        // validate if the user wants to continue
        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result == DialogResult.Yes ? true : false;
        }


        // clean text field
        private void cleanFields()
        {
            txtCode.Text = string.Empty;
        }


        // update code
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

                        log.addEventLog( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Codigo actualizado correctamente", ":)", MessageBoxButtons.OK );

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
         

        // validate empty text fields
        // validate if the code exists
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
