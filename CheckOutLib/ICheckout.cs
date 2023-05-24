using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutLib
{
    public interface ICheckout
    {
        decimal ScannedItemCount { get; set; }

        void Scan(string item);
        decimal GetTotalPrice();
    }
}
