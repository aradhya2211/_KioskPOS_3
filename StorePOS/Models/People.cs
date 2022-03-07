using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Models
{
    public class People : TimeStamp
    {
        [BsonId]
        public String _id { get; set; }
        [BsonRequired]
        public String Username { get; set; }
        [BsonRequired]
        public String Password { get; set; }
        public String DisplayName { get; set; }
        public String ImageUrl { get; set; }
        public People()
        {
            this._id = ObjectId.GenerateNewId(DateTime.Now).ToString();
        }
    }
}
