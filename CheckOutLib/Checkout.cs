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
        private Dictionary<char, Tuple<int, decimal>> _specialPrices;

       
        public Checkout(Dictionary<Char, decimal> unitPrices, Dictionary<char, int> itemCounts, Dictionary<char, Tuple<int, decimal>> specialPrices)
        {
            _unitPrices = unitPrices;
            _itemCounts = itemCounts;
            _specialPrices = specialPrices;
        }
        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0M;
            foreach (var item in _itemCounts.Keys)
            {
                int count = _itemCounts[item];
                decimal unitPrice = _unitPrices[item];
                if (_specialPrices.ContainsKey(item))
                {
                    Tuple<int, decimal> specialPrice = _specialPrices[item];
                    int specialCount = specialPrice.Item1;
                    decimal specialPriceValue = specialPrice.Item2;

                    int specialGroupCount = count / specialCount;
                    int remainingItems = count % specialCount;

                    totalPrice += specialGroupCount * specialPriceValue + remainingItems * unitPrice;
                }
                else
                {
                    totalPrice += unitPrice * count;
                }
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            if (item.Length != 1) throw new ArgumentException("Invalid item name.");

            var itemName = char.ToUpper(item[0]);

            if (!_unitPrices.ContainsKey(itemName))
            {
                throw new ArgumentException($"{itemName} does not exist.");
            }
            if (!_itemCounts.ContainsKey(itemName))
            {
                _itemCounts.Add(itemName, 0);
            }

            _itemCounts[itemName]++;
        }
    }
}
