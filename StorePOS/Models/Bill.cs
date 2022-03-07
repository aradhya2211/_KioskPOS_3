using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class Bill : TimeStamp
    {
        public String _id { get; set; }
        public List<BillItem> BillingItems { get; set; }
        public People Cashier { get; set; }
        public double Discount { get; set; }
        public double Estimate { get; set; }
        public double Total => Estimate + (Estimate * Discount) / 100;
       // public DateTime BillingDateTime { get; set; }
        public Bill()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
        }
    }
}
