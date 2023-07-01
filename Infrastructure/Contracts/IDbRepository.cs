using MongoDB.Driver;

namespace Infrastructure.Contracts
{
    public interface IDbRepository
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
        Task<TEntity> FindOneAsync<TEntity>(FilterDefinition<TEntity> filter);
        Task<List<TEntity>> FindManyAsync<TEntity>(FilterDefinition<TEntity> filter);
        Task InsertOneAsync<TEntity>(TEntity insertModel);
    }
}
