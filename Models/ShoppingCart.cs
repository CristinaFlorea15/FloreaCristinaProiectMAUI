using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloreaCristinaProiect.Models
{
    public class ShoppingCart
    {
        private static ShoppingCart _instance;
        public static ShoppingCart Instance => _instance ??= new ShoppingCart();
        public ObservableCollection<PastriesList> Items { get; private set; }

        private ShoppingCart()
        {
            Items = new ObservableCollection<PastriesList>();
        }

        public void AddItem(PastriesList item)
        {
            Items.Add(item);
        }

        public void RemoveItem(PastriesList item)
        {
            Items.Remove(item);
        }

        public void ClearCart()
        {
            Items.Clear();
        }
    }
}
