using System;
using System.Collections.Generic;
using System.Data;
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

        public string name { get; set; }

        public string email { get; set; }

        public long tel { get; set; }

        public State state { get; set; }

        public Client()
        {
            state = new State();
        }

        // -> METHODS, DATABASE QUERIES

        // add client method
        public bool addClient()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@clientName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@clientEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@clientTel", this.tel ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.ExecuteUpdateDeleteInsert( "AddClient" );

            return r > 0 ? true : false;
        }

        // update client method
        public bool updateClient()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@clientId", this.clientId ) );
            conn.ParamList.Add( new SqlParameter( "@clientName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@clientEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@clientTel", this.tel ) );
            int r = conn.ExecuteUpdateDeleteInsert( "UpdateClient" );

            return r > 0 ? true : false;
        }

        // delete client method
        public bool deleteClient()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@clientId", this.clientId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.ExecuteUpdateDeleteInsert( "DeleteClient" );

            return r > 0 ? true : false;
        }

        // query if the client email exists 
        public bool consultEmail()
        {
            Connection conn = new Connection();

            conn.ParamList.Add(new SqlParameter( "@clientEmail", this.email ) );
            DataTable responce = conn.ExecuteSelect( "ConsultClientEmail" );

            if (responce != null && responce.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        // query if the client tel exists
        public bool consultTel()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@clientTel", this.tel ) );
            DataTable responce = conn.ExecuteSelect( "ConsultClientTel" );

            if (responce != null && responce.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        // list all clients
        public DataTable list( int actives, string filter = "" )
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.ExecuteSelect( "ClientsList" );
        }

        

    }
}
