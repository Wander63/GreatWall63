using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutLib
{
    public class ItemSpecialDiscount
    {
        public int ItemQuantities { get; set; }
        public decimal ItemSpecialDiscountPrice { get; set; }

        public int ItemCarryBagQuantities { get; set; }
        public decimal ItemSpecialCarryBagPrice { get; set; }
    }
}
