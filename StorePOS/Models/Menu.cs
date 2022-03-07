using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class Menu
    {
        [BsonId]
        public String _id { get; set; }
        [BsonRequired]
        public String DisplayName { get; set; }
        public List<String> Menu_InventoryItemIds { get; set; }            //Inventory Items IDs
        public String AuthorId { get; set; }
        public Menu()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
        }
    }
}
