using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Logica.Models;
using System.Windows.Forms;

namespace PracticaEmpresarial_RobertChavesPerez
{
    public static class Globals
    {
        //ROBERT H. CHAVES PEREZ 2023


        public static Forms.MainForm StcMainForm = new Forms.MainForm();

        public static Forms.ClientsForm StcClientForm = new Forms.ClientsForm();

        public static Forms.SuppliersForm StcSupplierForm = new Forms.SuppliersForm();

        public static Logica.Models.User GlobalUser = new Logica.Models.User();

        public static Logica.Models.Client GlobalClient = new Logica.Models.Client();

    }
}
