﻿using Logica.Models;
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


        // execute fillDgv method
        private void LogsForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }


        // insert data into the data grid view
        private void fillDgv()
        {
            string fromDate = fromDTPicker.Value.ToString();
            string toDate = toDTPicker.Value.ToString();

            if ( compareDates() )
            {
                dtList = log.list( txtSearch.Text.Trim(), fromDate, toDate );
                dgvList.DataSource = dtList;
            }
            else
            {
                MessageBox.Show( "La fecha desde no puede ser mayor que la fecha hasta", ":)", MessageBoxButtons.OK );
            }
        }


        // validate schedules and dates
        private bool compareDates()
        {
            DateTime fromDate = fromDTPicker.Value.Date;
            DateTime toDate = toDTPicker.Value.Date;

            if ( DateTime.Compare( toDate, fromDate ).Equals( 1 ) ) return true;

            if ( DateTime.Equals( toDate, fromDate ) ) return true;

            return false;
        }


        // search specific characters into the data list
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if ( txtSearch.Text.Count() > 2 ||
                    string.IsNullOrEmpty( txtSearch.Text.Trim() ) )
            {
                fillDgv();
            }
        }


        // exit form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
