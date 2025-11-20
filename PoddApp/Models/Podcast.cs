using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models

{
    public class Podcast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PCID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Url { get; set; }
        public List<Episode> Episodes { get; set; } = new(); 

        public string? CategoryID { get; set; } 

        public Podcast(string url)
        {
            Url = url;
        }
        public string? ImageUrl { get; set; }

        public Podcast()
        {

        }
    }
}
