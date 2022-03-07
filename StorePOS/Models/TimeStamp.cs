using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class TimeStamp
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public TimeStamp()
        {
            CreatedAt = DateTime.Now;
        }
        public void ModifyVariable()
        {
            ModifiedAt = DateTime.Now;
        }
    }
}
