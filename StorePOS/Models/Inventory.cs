using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class Inventory : TimeStamp
    {
        [BsonId]
        public String _id { get; set; }
        public String DisplayName { get; set; }
        public List<String> InventoryItemIDs { get; set; }
        public Inventory()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
        }
    }
}
