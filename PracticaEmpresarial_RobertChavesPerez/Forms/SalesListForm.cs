using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaEmpresarial_RobertChavesPerez.Forms
{
    public partial class SalesListForm : Form
    {
        Logica.Models.Sale sale { set; get; }

        Logica.Models.Logg log { set; get; }

        DataTable dtList { set; get; }

        private int tempState { set; get; }

        long tempSaleId { set; get; }

        private string[] deleteVector { get; set; }

        public SalesListForm()
        {
            InitializeComponent();

            sale = new Logica.Models.Sale();

            log = new Logica.Models.Logg();

            dtList = new DataTable();

            deleteVector = new string[4];
        }


        // insert data into the data grid view
        private void fillDgv()
        {
            string fromDate = fromDTPicker.Value.ToString();
            string toDate = toDTPicker.Value.ToString();

            int active = cbActive();

            if ( compareDates() )
            {
                dtList = sale.list( active, txtSearch.Text.Trim(), fromDate, toDate );
                dgvList.DataSource = dtList;
            }
            else
            {
                MessageBox.Show( "La fecha desde no puede ser mayor que la fecha hasta", ":)", MessageBoxButtons.OK );
            }
        }


        private int cbActive()
        {
            if ( cbActivos.Checked )
            {
                tempState = 2;
                return 1;
            }
            else
            {
                tempState = 1;
                return 2;
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


        // load data into the form
        private void SalesListForm_Load(object sender, EventArgs e)
        {
            fillDgv();
        }


        // exit form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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


        // show inactivated sales
        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            fillDgv();

            cbActive();
        }


        // select a sale
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvList.SelectedRows.Count.Equals( 1 ) )
            {
                DataGridViewRow dgvr = dgvList.SelectedRows[0];

                int dgvIndex = dgvr.Index;

                tempSaleId = Convert.ToInt64( dtList.Rows[dgvr.Index][0] );
            }
        }


        // create ticket method
        private void createTicket( Sale sale )
        {
            Report report = new Report();

            report.Show();

            CrystalReport cr = new CrystalReport();

            DataTable dt = sale.ticket();

            cr.SetDataSource(dt);

            report.crystalReportV1.ReportSource = cr;

            report.crystalReportV1.Refresh();
        }


        // create a ticket
        private void btnTicket_Click(object sender, EventArgs e)
        {
            if ( tempSaleId > 0 )
            {
                sale = new Sale();
                sale.saleId = tempSaleId;

                createTicket(sale);
            }
            else
            {
                MessageBox.Show( "Debes seleccionar una venta primero", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


        // delete sale
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ( tempSaleId > 0 )
            {
                sale = new Logica.Models.Sale();

                sale.saleId = tempSaleId;
                sale.state.stateId = tempState;

                deleteMethod();

                string text = "Quieres" + deleteVector[0] + "la venta id: {0} ?";
                string id = Convert.ToString( sale.saleId );

                bool msg = validateYesOrNot( text, id );

                if ( msg )
                {
                    bool ok = sale.deleteSale();

                    if ( ok )
                    {
                        string detail = string.Format( deleteVector[1] + "al la venta ID: {0}", id );

                        log.addEventLog( detail, Globals.GlobalUser.userId );

                        MessageBox.Show( "Venta fue" + deleteVector[2] + "correctamente", ":)", MessageBoxButtons.OK );

                        cleanFields();

                        fillDgv();
                    }
                    else
                    {
                        MessageBox.Show( "No se" + deleteVector[3] + "la venta", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
            else
            {
                MessageBox.Show( "Selecciona la venta que desea" + deleteVector[0], ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // load delete or active the client
        private void deleteMethod()
        {
            if ( tempState.Equals(2) )
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


        // clean text fields
        private void cleanFields()
        {
            tempSaleId = 0;
        }


        // validate if user wants to continue
        private bool validateYesOrNot( string text, string description )
        {
            string msg = string.Format( text, description );

            DialogResult result = MessageBox.Show( msg, "[?]", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            return result.Equals( DialogResult.Yes ) ? true : false;
        }



    }
}
