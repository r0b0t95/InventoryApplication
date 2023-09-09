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
            supplier.tel = Convert.ToInt32( txtTel.Text.Trim() );
            supplier.state.stateId = 1;

            if ( string.IsNullOrEmpty( validate ) )
            {
                bool msg = validateYesOrNot( supplier.name );

                if ( msg )
                {
                    bool ok = supplier.addSupplier();

                    if (ok)
                    {
                        MessageBox.Show( "Proveedor agregado correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();
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

        private bool validateYesOrNot( string description )
        {
            string msg = string.Format( "Quieres agregar al proveedor: {0} ?", description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo );

            return result == DialogResult.Yes ? true : false;
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
    }
}
