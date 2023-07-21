using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Product
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> PRODUCT ATTRIBUTES

        public long productId { get; set; }

        public string code { get; set; }

        public string description { get; set; }

        public int cant { get; set; }

        public double price { get; set; }

        public State productState { get; set; }

        public Product()
        {
            productState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addProduct()
        {
            bool R = false;
            return R;
        }

        public bool updateProduct()
        {
            bool R = false;
            return R;
        }

        public bool deleteProduct()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> code

        //TODO: method -> description

    }
}
