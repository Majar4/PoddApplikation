using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string CategoryID { get; set; }

        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public Category()
        {

        }
    }
}
