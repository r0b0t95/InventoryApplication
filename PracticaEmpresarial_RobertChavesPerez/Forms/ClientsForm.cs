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

            if (string.IsNullOrEmpty(validate))
            {
                MessageBox.Show(validate, "Se registro con exito", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(validate, "Error", MessageBoxButtons.OK);
            }
        }

        private string validateFields()
        {
            string responce = "El campo {0} esta vacio";

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                return string.Format(responce, "nombre");
            }

            return string.Empty;
        }
    }
}
