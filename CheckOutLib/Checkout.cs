using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutLib
{
    public class Checkout : ICheckout
    {
        public decimal ScannedItemCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
