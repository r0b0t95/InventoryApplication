using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Purchase
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> ORDER ATTRIBUTES

        public long orderId { get; set; }

        public string description { get; set; }

        public DateTime date { get; set; }

        public State purchaseState { get; set; }

        public Purchase()
        {
            purchaseState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addPurchase()
        {
            bool R = false;
            return R;
        }

        public bool updatePurchase()
        {
            bool R = false;
            return R;
        }

        public bool deletePurchase()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> orders list

    }
}
