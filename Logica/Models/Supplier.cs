﻿using System;
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

        public int tel { get; set; }

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
            bool R = false;
            return R;
        }

        public bool deleteSupplier()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> consult by name

        public DataTable list( bool actives = true, string filter = "" )
        {
            DataTable dt = new DataTable();

            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            dt = conn.PerformSelect( "suppliersList" );

            return dt;
        }

    }
}
