using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Supplier
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> SUPPLIER ATTRIBUTES

        public long supplierId { get; set; }

        public string name { get; set; }

        public int tel { get; set; }

        public string email { get; set; }

        public string description { get; set; }

        public State supplierState { get; set; }

        public Supplier()
        {
            supplierState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addSupplier()
        {
            bool R = false;
            return R;
        }

        public bool updateSupplier()
        {
            bool R = false;
            return R;
        }

        public bool deleteSupplier()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> consult by name

        //TODO: method -> consult by description

        //TODO: method -> list of suppliers

    }
}
