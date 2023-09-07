using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Client
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> CLIENT ATTRIBUTES

        public long clientId { get; set; }

        public string clientName { get; set; }

        public string clientEmail { get; set; }

        public long clientTel { get; set; }

        public State clientState { get; set; }

        public Client()
        {
            clientState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addClient()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@clientName", this.clientName ) );
            conn.ParamList.Add( new SqlParameter( "@clientEmail", this.clientEmail ) );
            conn.ParamList.Add( new SqlParameter( "@clientTel", this.clientTel ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.clientState.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddClient" );

            return r > 0 ? true : false;
        }

        public bool updateClient()
        {
            bool R = false;
            return R;
        }

        public bool deleteClient()
        {
            bool R = false;
            return R;
        }

    }
}
