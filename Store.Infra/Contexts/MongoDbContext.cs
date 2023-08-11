using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Store.Domain.Entities;
using Store.Infra.Settings;

namespace Store.Infra.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
    }
}
