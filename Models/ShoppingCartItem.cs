using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FloreaCristinaProiect.Models
{
    public class ShoppingCartItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int PastryID { get; set; } // Foreign key to PastriesList

        public string Name { get; set; }

        public int Quantity { get; set; } // Quantity of the item

        public int Price { get; set; } // Price of one unit

        public int TotalPrice => Quantity * Price; // Total price for the quantity

        public string PastriesImage { get; set; } // Image URL or Path
    }
}
