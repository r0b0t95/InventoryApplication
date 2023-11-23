using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Rol
    {
        //ROBERT H. CHAVES PEREZ 2023

        // -> ROL ATTRIBUTES

        public long rolId { get; set; }

        public string rolName { get; set; }
        
        // list all roles
        public DataTable list()
        {
            Connection conn = new Connection();

            return conn.ExecuteSelect( "RoleList" );
        }

    }
}
