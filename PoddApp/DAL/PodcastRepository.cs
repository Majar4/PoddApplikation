using Models;
using MongoDB.Driver;

namespace DAL
{
    public class PodcastRepository : IRepository<Podcast>
    {

        private readonly IMongoCollection<Podcast> PodcastCollection;

        public PodcastRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            PodcastCollection = db.GetCollection<Podcast>("AllPodcasts");
        }


        public async Task AddAsync(Podcast savedPodcast)
        {
            using var session = await PodcastCollection.Database.Client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                await PodcastCollection.InsertOneAsync(session, savedPodcast);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }


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


        public async Task<bool> UpdateAsync(Podcast enPodcast)
        {
            using var session = await PodcastCollection.Database.Client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.PCID, enPodcast.PCID);
                var update = Builders<Podcast>.Update.Set(p => p.Name, enPodcast.Name)
                    .Set(p => p.CategoryID, enPodcast.CategoryID);
                var result = await PodcastCollection.UpdateOneAsync(session, filter, update);
                await session.CommitTransactionAsync();
                return result.ModifiedCount > 0;
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        
        public async Task DeleteAsync(string podcastID)
        {
            using var session = await PodcastCollection.Database.Client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.PCID, podcastID);
                await PodcastCollection.DeleteOneAsync(session, filter);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }
    }
}
