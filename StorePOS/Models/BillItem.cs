using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class BillItem : ProductBase
    {
        public String _id { get; set; }
        public int BillingQuantity { get; set; }
        public double BillingSubCost { get; set; }
        public BillItem()
        {
            BillingQuantity = 1;
            Cost = 0;
            BillingSubCost = BillingQuantity * Cost;
        }
    }
}
