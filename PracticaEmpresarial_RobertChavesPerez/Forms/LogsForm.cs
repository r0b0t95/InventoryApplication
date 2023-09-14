using Logica.Models;
using System;
using System.Collections;
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
    public partial class LogsForm : Form
    {
        Logica.Models.Logg log { set; get; }

        DataTable dtList { set; get; }

        public LogsForm()
        {
            InitializeComponent();

            log = new Logica.Models.Logg();

            dtList = new DataTable();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void fillDgv()
        {
            string fromDate = fromDTPicker.Text.ToString();
            string toDate = toDTPicker.Value.ToString();

            dtList = log.list( txtSearch.Text.Trim(), fromDate, toDate );

            dgvList.DataSource = dtList;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearch.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearch.Text.Trim() ) )
            {
                fillDgv();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
