using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Sale
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> CLIENT ATTRIBUTES

        public long saleId { get; set; }

        public string detail { get; set; }

        public DateTime date { get; set; }

        public double subTotal { get; set; }

        public double discount { get; set; }

        public double tax { get; set; }

        public double total { get; set; }

        public User user { get; set; }

        public Client client { get; set; }

        public State state { get; set; }


        public Sale()
        {
            user = new User();

            client = new Client();

            state = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addSale()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@saleDetail", this.detail ) );
            conn.ParamList.Add( new SqlParameter( "@saleDate", this.date ) );
            conn.ParamList.Add( new SqlParameter( "@saleSubTotal", this.subTotal ) );
            conn.ParamList.Add( new SqlParameter( "@saleDiscount", this.discount ) );
            conn.ParamList.Add( new SqlParameter( "@saleTax", this.tax ) );
            conn.ParamList.Add( new SqlParameter( "@saleTotal", this.total ) );
            conn.ParamList.Add( new SqlParameter( "@fkUser", this.user.userId ) );
            conn.ParamList.Add( new SqlParameter( "@fkClient", this.client.clientId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddSale" );

            return r > 0 ? true : false;
        }

        public bool deleteSale()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@saleId", this.saleId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "DeleteSale" );

            return r > 0 ? true : false;
        }


        public DataTable list( int actives, string filter = "", string from = "", string to = "" )
        {
            Connection conn = new Connection();


            DateTime fromDate = Convert.ToDateTime( from );
            DateTime toDate = Convert.ToDateTime( to );

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );
            conn.ParamList.Add( new SqlParameter( "@fromDate", fromDate ) );
            conn.ParamList.Add( new SqlParameter( "@toDate", toDate ) );

            return conn.PerformSelect( "SalesList" );
        }

        public DataTable billDetailsScheme()
        {
            DataTable dt = new DataTable();

            Connection conn = new Connection();

            dt = conn.PerformSelect( "BillDetailsScheme" );

            dt.PrimaryKey = null;

            return dt;
        }

    }
}
