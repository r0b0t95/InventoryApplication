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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();

            new MainForm().Show();

            this.Close();
        }
    }
}
