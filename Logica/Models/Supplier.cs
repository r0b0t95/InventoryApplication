using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Supplier
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> SUPPLIER ATTRIBUTES

        public long supplierId { get; set; }

        public string name { get; set; }

        public long tel { get; set; }

        public string email { get; set; }

        public string description { get; set; }

        public State state { get; set; }

        public Supplier()
        {
            state = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addSupplier()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@supplierName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@supplierEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@supplierTel", this.tel ) );
            conn.ParamList.Add( new SqlParameter( "@supplierDescription", this.description ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddSupplier" );

            return r > 0 ? true : false;
        }

        public bool updateSupplier()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@supplierId", this.supplierId ) );
            conn.ParamList.Add( new SqlParameter( "@supplierName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@supplierEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@supplierTel", this.tel ) );
            conn.ParamList.Add( new SqlParameter( "@supplierDescription", this.description ) );
            int r = conn.PerformUpdateDeleteInsert( "UpdateSupplier" );

            return r > 0 ? true : false;
        }

        public bool deleteSupplier()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@supplierId", this.supplierId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "DeleteSupplier" );

            return r > 0 ? true : false;
        }

        //TODO: method -> consult by name

        public DataTable list( bool actives = true, string filter = "" )
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.PerformSelect( "SuppliersList" );
        }

    }
}
