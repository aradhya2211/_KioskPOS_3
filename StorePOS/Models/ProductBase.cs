using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class ProductBase : TimeStamp
    {
        public String DisplayName { get; set; }
        public String Category { get; set; }
        public double Cost { get; set; }
        public double Tax { get; set; }
    }
}
