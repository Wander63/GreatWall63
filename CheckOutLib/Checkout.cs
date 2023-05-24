using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutLib
{
    public class Checkout : ICheckout
    {
        private List<char> _items;

        public int ScannedItemCount { get => _items.Count; set => throw new NotImplementedException(); }

        public Checkout(List<Char> items)
        {
            _items = items;
        }
        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            if (item.Length != 1) throw new ArgumentException("Invalid item name.");

            _items.Add(item[0]);
        }
    }
}
