using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BL
{
    public class MongoDBService : IMongoDBService
    {
       
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly HttpClient _http;

        public MongoDBService(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
            _http = new HttpClient();
        }
        
        public IPodcastService createPodcastService()
        {
            var rssClient = new RssReaderClient(_http);
            var podcastRepo = new PodcastRepository(_connectionString, _databaseName);
            return new PodcastService(podcastRepo, rssClient);


        }

        public ICategoryService createCategoryService()
        {
            var categoryRepo = new CategoryRepository(_connectionString, _databaseName);
            return new CategoryService(categoryRepo);
        }
    }
}
