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

            Connection conn = new Connection();

            /*
             //lista de parámetros para el insert
            MiCnn.ListaParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            MiCnn.ListaParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaParametros.Add(new SqlParameter("@NombreUsuario", this.NombreUsuario));

            Crypto MiEncriptador = new Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);
            MiCnn.ListaParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));

            MiCnn.ListaParametros.Add(new SqlParameter("@Email", this.Email));

            //Parametros para los FKs, normalmente son de objetos compuestos de la clase 
            MiCnn.ListaParametros.Add(new SqlParameter("@IDRol", this.MiRol.IDUsuarioRol));
            MiCnn.ListaParametros.Add(new SqlParameter("@IDEmpresa", this.MiEmpresa.IDEmpresa));

            int Resultado = MiCnn.EjecutarUpdateDeleteInsert("SPUsuarioAgregar");

            if (Resultado > 0)
            {
                R = true;
            }
            */


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
