using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Product
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> PRODUCT ATTRIBUTES

        public long productId { get; set; }

        public string detail { get; set; }

        public int cant { get; set; }

        public double price { get; set; }

        public Code code { get; set; }

        public State state { get; set; }


        public Product()
        {
            code = new Code();

            state = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addProduct()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@productDetail", this.detail ) );
            conn.ParamList.Add( new SqlParameter( "@cant", this.cant ) );
            conn.ParamList.Add( new SqlParameter( "@price", this.price ) );
            conn.ParamList.Add( new SqlParameter( "@fkCode", this.code.codeId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddProduct" );

            return r > 0 ? true : false;
        }

        public bool updateProduct()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@productId", this.productId ) );
            conn.ParamList.Add( new SqlParameter( "@productDetail", this.detail ) );
            conn.ParamList.Add( new SqlParameter( "@cant", this.cant ) );
            conn.ParamList.Add( new SqlParameter( "@price", this.price ) );
            conn.ParamList.Add( new SqlParameter( "@fkCode", this.code.codeId ) );
            int r = conn.PerformUpdateDeleteInsert( "UpdateProduct" );

            return r > 0 ? true : false;
        }

        public bool deleteProduct()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@productId", this.productId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "DeleteProduct" );

            return r > 0 ? true : false;
        }

        public DataTable list( int actives, string filter = "" )
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.PerformSelect( "ProductsList" );
        }


    }
}
