using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace DAL
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IMongoCollection<Category> CategoryCollection;

        public CategoryRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            CategoryCollection = db.GetCollection<Category>("AllCategories");
        }

        //C
        public async Task AddAsync(Category aCategory)
        {
            await CategoryCollection.InsertOneAsync(aCategory);
        }

        //R
        public async Task<List<Category?>> GetAllAsync()
        {
            var filter = FilterDefinition<Category>.Empty;
            var allCategories = await CategoryCollection.Find(filter).ToListAsync();
            return allCategories;
        }

        public async Task<Category> GetByIdAsync(string Id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryID, Id);
            return await CategoryCollection.Find(filter).FirstOrDefaultAsync();
        }

        //U
        public async Task<bool> UpdateAsync(Category aCategory)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryID, aCategory.CategoryID);
            var update = Builders<Category>.Update.Set(c => c.Name, aCategory.Name);
            var result = await CategoryCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        //D
        public async Task DeleteAsync(string categoryID)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.CategoryID, categoryID);
            await CategoryCollection.DeleteOneAsync(filter);
        }
    }
}
