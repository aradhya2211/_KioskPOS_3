using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class Store : TimeStamp
    {
        [BsonId]
        public String _id { get; set; }
        public String Name { get; set; }
        public List<People> Employees { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public List<Bill> Bills { get; set; }
        public Store()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
        }


    }
}
