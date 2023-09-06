using System;
using System.Collections.Generic;
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

        public string userName { get; set; }

        public string userEmail { get; set; }

        public string password { get; set; }

        public State userState { get; set; }

        public User()
        {
            userState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addUser()
        {
            Connection conn = new Connection();

            Encryption encrypt = new Encryption();

            string hash = encrypt.EncryptText( this.password );

            conn.ParamList.Add( new SqlParameter( "@userName", this.userName ) );
            conn.ParamList.Add( new SqlParameter( "@userEmail", this.userEmail ) );
            conn.ParamList.Add( new SqlParameter( "@password", hash ) );
            conn.ParamList.Add( new SqlParameter( "@fkState", this.userState.stateId ) );
            int r = conn.PerformUpdateDeleteInsert( "AddUser" );

            return r > 0 ? true : false;
        }

        public bool updateUser()
        {
            bool R = false;
            return R;
        }

        public bool deleteUser()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> consult by email

        //TODO: method -> users list

    }
}
