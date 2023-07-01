using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.Extensions.Options;

using MongoDB.Driver;



namespace Infrastructure.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly IMongoDatabase _database;

        public DbRepository(IOptions<TechTalkDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            _database = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            var collectionName = nameof(TEntity);
            return _database.GetCollection<TEntity>(collectionName);
        }

        public async Task InsertOneAsync<TEntity>(TEntity insertModel)
        {
            IMongoCollection<TEntity> collection = GetCollection<TEntity>();
            await collection.InsertOneAsync(insertModel);
        }

        public async Task<TEntity> FindOneAsync<TEntity>(FilterDefinition<TEntity> filter)
        {
            var collection = GetCollection<TEntity>();
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> FindManyAsync<TEntity>(FilterDefinition<TEntity> filter)
        {
            var collection = GetCollection<TEntity>();
            return await collection.Find(filter).ToListAsync<TEntity>();
        }
    }
}
