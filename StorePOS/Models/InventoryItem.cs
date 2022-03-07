using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class InventoryItem : ProductBase
    {
        [BsonId]
        public String _id { get; set; }
        public int Quantity { get; set; }
        public String Make { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        public InventoryItem()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
            this.Category = "General";
        }
    }
}
