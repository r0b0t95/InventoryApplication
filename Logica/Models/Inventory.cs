using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Inventory
    {

        //ROBERT H. CHAVES PEREZ 2023

        // -> INVENTORY ATTRIBUTES

        public long detailId { get; set; }

        public long product { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}
