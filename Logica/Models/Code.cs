using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Code
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> CODE ATTRIBUTES

        public long codeId { get; set; }

        public string code { get; set; }


        // -> METHODS, DATABASE QUERIES

        public bool addCode()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@code", this.code) );
            int r = conn.ExecuteUpdateDeleteInsert( "AddCode" );

            return r > 0 ? true : false;
        }

        public bool updateCode()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@codeId", this.codeId) );
            conn.ParamList.Add( new SqlParameter( "@code", this.code) );
            int r = conn.ExecuteUpdateDeleteInsert( "UpdateCode" );

            return r > 0 ? true : false;
        }

        public bool consultCode()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@code", this.code ) );
            DataTable responce = conn.ExecuteSelect( "ConsultCode" );

            if ( responce != null && responce.Rows.Count > 0 )
            {
                return true;
            }

            return false;
        }

        public DataTable list( string filter = "" )
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.ExecuteSelect( "CodeList" );
        }

    }
}
