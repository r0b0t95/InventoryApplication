using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class User
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> USER ATTRIBUTES

        public long userId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public State state { get; set; }

        public Rol rol { get; set; }

        public User()
        {
            state = new State();
            rol = new Rol();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addUser()
        {
            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@userEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            conn.ParamList.Add( new SqlParameter( "@fkRol", this.rol.rolId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddUser" );

            return r > 0 ? true : false;
        }

        public bool updateUser()
        {
            Connection conn = new Connection();
            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@userEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@fkRol", this.rol.rolId ) );
            int r = conn.PerformUpdateDeleteInsert( "UpdateUser" );

            return r > 0 ? true : false;
        }

        public bool updatePassword()
        {
            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            int r = conn.PerformUpdateDeleteInsert( "UpdatePassword" );

            return r > 0 ? true : false;
        }

        public bool deleteUser()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "DeleteUser" );

            return r > 0 ? true : false;
        }

        public int loginUser()
        {
            int r = 0;

            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            DataTable responce = conn.PerformSelect( "LoginUser" );

            if ( responce != null && responce.Rows.Count > 0 )
            {
                DataRow row = responce.Rows[0];
                r = Convert.ToInt32( row["userId"] );
            }

            return r;
        }

        //TODO: method -> consult by email

        public DataTable list(bool actives = true, string filter = "")
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.PerformSelect( "UsersList" );
        }

    }
}
