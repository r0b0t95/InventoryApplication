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
    public partial class SuppliersForm : Form
    {
        private Logica.Models.Supplier supplier;

        private Logica.Models.Logg log { get; set; }

        public long tempId { get; set; }

        public SuppliersForm()
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

            supplier = new Logica.Models.Supplier();

            supplier.name = txtName.Text.Trim();
            supplier.email = txtEmail.Text.Trim();  
            supplier.description = txtDescription.Text.Trim();
            supplier.tel = Convert.ToInt64( txtTel.Text.Trim() );
            supplier.state.stateId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres agregar al proveedor: {0} ?";

                bool msg = validateYesOrNot( text, supplier.name );

                if ( msg )
                {
                    bool ok = supplier.addSupplier();

                    if ( ok )
                    {
                        string detail = string.Format( "Agrego al proveedor: {0}", supplier.name );

                        addLogEvent( detail );

                        MessageBox.Show( "Proveedor agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se agrego el proveedor", ":(", MessageBoxButtons.OK );
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

            if (string.IsNullOrWhiteSpace( txtName.Text ) )
            {
                return string.Format( responce, "telefono" );
            }

            return string.Empty;
        }

        private void cleanFields()
        {
            txtName.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit( e.KeyChar ) && e.KeyChar != '\b' ) e.Handled = true;
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void loadForm()
        {
            if ( this.tempId.Equals( 0 ) )
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string validate = validateFields();

            supplier = new Logica.Models.Supplier();

            supplier.supplierId = tempId;
            supplier.name = txtName.Text.Trim();
            supplier.tel = Convert.ToInt64( txtTel.Text.Trim() );
            supplier.email = txtEmail.Text.Trim();
            supplier.description = txtDescription.Text.Trim();

            if ( string.IsNullOrEmpty( validate ) )
            {
                string text = "Quieres actualizar al proveedor: {0} ?";

                bool msg = validateYesOrNot( text, supplier.name );

                if ( msg )
                {
                    bool ok = supplier.updateSupplier();

                    if ( ok )
                    {
                        string detail = string.Format( "Actualizo al proveedor: {0}", supplier.name );

                        addLogEvent( detail );

                        MessageBox.Show( "Proveedor actualizado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show( "No se actualizo el proveedor", ":(", MessageBoxButtons.OK );
                    }
                }
            }
            else
            {
                MessageBox.Show( validate, "Error", MessageBoxButtons.OK );
            }
        }

        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
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
