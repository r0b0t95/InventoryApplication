using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Logg
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> LOG ATTRIBUTES

        public long logId { get; set; }

        public string logDetail { get; set; }

        public DateTime logDate { get; set; }

        public User user { get; set; }

        public Logg() 
        {
            user = new User();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addLog()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@logDetail", this.logDetail ) );
            conn.ParamList.Add( new SqlParameter( "@logDate", this.logDate ) );
            conn.ParamList.Add( new SqlParameter( "@fkUser", this.user.userId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddLogg" );

            return r > 0 ? true : false;
        }


        public DataTable list( string filter = "", string from = "", string to = "" )
        {
            Connection conn = new Connection();

            DateTime fromDate = Convert.ToDateTime( from );
            DateTime toDate = Convert.ToDateTime( to );

            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );
            conn.ParamList.Add( new SqlParameter( "@fromDate", fromDate ) );
            conn.ParamList.Add( new SqlParameter( "@toDate", toDate ) );

            return conn.PerformSelect( "LoggsList" );
        }

    }
}
