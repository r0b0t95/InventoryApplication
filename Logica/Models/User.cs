using System;
using System.Collections.Generic;
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

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public State userState { get; set; }

        public User()
        {
            userState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addUser()
        {
            bool R = false;
            return R;
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
