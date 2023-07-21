using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Order
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> ORDER ATTRIBUTES

        public long orderId { get; set; }

        public string description { get; set; }

        public DateTime date { get; set; }

        public State orderState { get; set; }

        public Order()
        {
            orderState = new State();
        }

        // -> METHODS, DATABASE QUERIES

        public bool addOrder()
        {
            bool R = false;
            return R;
        }

        public bool updateOrder()
        {
            bool R = false;
            return R;
        }

        public bool deleteOrder()
        {
            bool R = false;
            return R;
        }

        //TODO: method -> orders list

    }
}
