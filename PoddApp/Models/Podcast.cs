//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

namespace Models

{
    public class Podcast
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //[BsonId]
        //[BsonRepresantation(BsonType.ObjectId)]
        public string PCID { get; set; }
        public string Url { get; set; }
        public List<Episode> episodes { get; set; } = new(); 

        public string? CategoryID { get; set; } 

        public Podcast(string url)
        {
            Url = url;
        }

        public Podcast()
        {

        }
    }
}
