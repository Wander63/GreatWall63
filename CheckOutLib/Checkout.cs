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
        private Dictionary<char, decimal> _unitPrices;
        private Dictionary<char, int> _itemCounts;

        public int ScannedItemCount { get => _itemCounts.Count; set => throw new NotImplementedException(); }

        public Checkout(Dictionary<Char, decimal> unitPrices, Dictionary<char, int> itemCounts)
        {
            _unitPrices = unitPrices;
            _itemCounts = itemCounts;
        }
        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            if (item.Length != 1) throw new ArgumentException("Invalid item name.");

            var itemName = char.ToUpper(item[0]);

            if(!_unitPrices.ContainsKey(itemName))
            {
                throw new ArgumentException($"{itemName} does not exist.");
            }
            if(!_itemCounts.ContainsKey(itemName))
            {
                _itemCounts.Add(itemName, 0);
            }

            _itemCounts[itemName]++;
        }
    }
}
