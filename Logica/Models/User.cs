using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
            int r = conn.ExecuteUpdateDeleteInsert( "AddUser" );

            return r > 0 ? true : false;
        }

        public bool updateUser()
        {
            Connection conn = new Connection();
            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@userEmail", this.email ) );
            conn.ParamList.Add( new SqlParameter( "@fkRol", this.rol.rolId ) );
            int r = conn.ExecuteUpdateDeleteInsert( "UpdateUser" );

            return r > 0 ? true : false;
        }

        public bool updatePassword()
        {
            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            int r = conn.ExecuteUpdateDeleteInsert( "UpdatePassword" );

            return r > 0 ? true : false;
        }

        public bool deleteUser()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@userId", this.userId ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.state.stateId ) );
            int r = conn.ExecuteUpdateDeleteInsert( "DeleteUser" );

            return r > 0 ? true : false;
        }

        public int[] loginUser()
        {
            int[] r = {0, 0};

            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            DataTable responce = conn.ExecuteSelect( "LoginUser" );

            if ( responce != null && responce.Rows.Count > 0 )
            {
                DataRow row = responce.Rows[0];
                r[0] = Convert.ToInt32( row["userId"] );
                r[1] = Convert.ToInt32( row["fkState"] );
            }

            return r;
        }

        public string recoveryPassword()
        {
            string pass = string.Empty;

            Connection conn = new Connection();

            Encryption decrypt = new Encryption();

            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            conn.ParamList.Add( new SqlParameter( "@email", this.email ) );
            DataTable responce = conn.ExecuteSelect( "PasswordRecovery" );

            if ( responce != null && responce.Rows.Count > 0 )
            {
                DataRow row = responce.Rows[0];
                string hash = Convert.ToString( row["password"] );

                string tempPassword = decrypt.DecryptText( hash );

                if ( tempPassword.Contains( this.password ) )
                {
                    pass = tempPassword;
                }
            }

            return pass;
        }

        public bool consultName()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@userName", this.name ) );
            DataTable responce = conn.ExecuteSelect( "ConsultUserName" );

            if ( responce != null && responce.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool consultEmail()
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@userEmail", this.email ) );
            DataTable responce = conn.ExecuteSelect( "ConsultUserEmail" );

            if ( responce != null && responce.Rows.Count > 0 )
            {
                return true;
            }

            return false;
        }

        public DataTable list( int actives, string filter = "" )
        {
            Connection conn = new Connection();

            conn.ParamList.Add( new SqlParameter( "@actives", actives ) );
            conn.ParamList.Add( new SqlParameter( "@filter", filter ) );

            return conn.ExecuteSelect( "UsersList" );
        }

    }
}
