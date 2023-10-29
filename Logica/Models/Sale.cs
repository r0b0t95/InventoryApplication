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

        // -> SALE ATTRIBUTES

        public long saleId { get; set; }

        public List<Inventory> detail { get; set; }

        public DateTime date { get; set; }

        public decimal subTotal { get; set; }

        public decimal discount { get; set; }

        public decimal tax { get; set; }

        public decimal total { get; set; }

        public User user { get; set; }

        public Client client { get; set; }

        public State state { get; set; }


        public Sale()
        {
            user = new User();

            client = new Client();

            state = new State();

            detail = new List<Inventory>();
        }

        // -> METHODS, DATABASE QUERIES

        public int addSale()
        {
            int reponse = 0;

            Connection conn = new Connection();

            //conn.ParamList.Add( new SqlParameter( "@saleDetail", this.detail ) );
            conn.ParamList.Add( new SqlParameter( "@saleDate", this.date ) );
            conn.ParamList.Add( new SqlParameter( "@saleSubTotal", this.subTotal ) );
            conn.ParamList.Add( new SqlParameter( "@saleDiscount", this.discount ) );
            conn.ParamList.Add( new SqlParameter( "@saleTax", this.tax ) );
            conn.ParamList.Add( new SqlParameter( "@saleTotal", this.total ) );
            conn.ParamList.Add( new SqlParameter( "@fkUser", this.user.userId ) );
            conn.ParamList.Add( new SqlParameter( "@fkClient", this.client.clientId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );

            object Retorno = conn.ExecuteScalarReturn( "AddSale" );

            if ( Retorno != null )
            {
                this.saleId = Convert.ToInt64( Retorno.ToString() );

                int collector = 0;

                foreach ( Inventory item in this.detail )
                {

                    Connection connDetail = new Connection();

                    connDetail.ParamList.Add( new SqlParameter( "@fkSale", saleId ) );
                    connDetail.ParamList.Add( new SqlParameter( "@fkProduct", item.product ) );
                    connDetail.ParamList.Add( new SqlParameter( "@quantity", item.quantity ) );
                    connDetail.ParamList.Add( new SqlParameter( "@price", item.price ) );

                    connDetail.ExecuteUpdateDeleteInsert( "AddDetail" );

                    collector += 1;
                }

                reponse = collector;
            }

            return reponse;
        }


        public bool deleteSale()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@saleId", this.saleId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.ExecuteUpdateDeleteInsert( "DeleteSale" );

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

            return conn.ExecuteSelect( "SalesList" );
        }

        public DataTable billDetailsScheme()
        {
            DataTable dt = new DataTable();

            Connection conn = new Connection();

            dt = conn.ExecuteSelect( "BillDetailsScheme" );

            dt.PrimaryKey = null;

            return dt;
        }

        public DataTable ticket()
        {
            Connection conn = new Connection();

            return conn.ExecuteSelect( "Ticket" );
        }

    }
}
