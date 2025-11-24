using Models;
using MongoDB.Driver;

namespace DAL
{
    public class PodcastRepository : IRepository<Podcast>
    {
        //private readonly List<Podcast> allPodcasts;
        private readonly IMongoCollection<Podcast> PodcastCollection;

        public PodcastRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            PodcastCollection = db.GetCollection<Podcast>("AllPodcasts");
        }

        //C
        public async Task AddAsync(Podcast savedPodcast) { 
            await PodcastCollection.InsertOneAsync(savedPodcast);
        }

        //R
        public async Task<List<Podcast?>> GetAllAsync()
        {
            var filter = FilterDefinition<Podcast>.Empty;
            var allPodcasts = await PodcastCollection.Find(filter).ToListAsync();
            return allPodcasts;
        }

        public async Task<Podcast> GetByIdAsync(string Id)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.PCID, Id);
            return await PodcastCollection.Find(filter).FirstOrDefaultAsync();
        }
            

        //U
        public async Task<bool> UpdateAsync(Podcast enPodcast) {
            var filter = Builders<Podcast>.Filter.Eq(p => p.PCID, enPodcast.PCID);
            var update = Builders<Podcast>.Update.Set(p => p.Name, enPodcast.Name)
                .Set(p => p.CategoryID, enPodcast.CategoryID);
            var result = await PodcastCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        //D
        public async Task DeleteAsync(string podcastID) { 
            var filter = Builders<Podcast>.Filter.Eq(p => p.PCID, podcastID);
            await PodcastCollection.DeleteOneAsync(filter);
        }
    }
}
