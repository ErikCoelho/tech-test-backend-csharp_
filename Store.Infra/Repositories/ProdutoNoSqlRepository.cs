using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Infra.Repositories
{
    public class ProdutoNoSqlRepository : IProdutoNoSqlRepository
    {
        private readonly IMongoCollection<Produto> _produtoCollection;
        private readonly string _collectionName = "Collection1";
        private readonly string _databaseName = "store";

        public ProdutoNoSqlRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbConnectionString"]);
            var database = client.GetDatabase(_databaseName);
            _produtoCollection = database.GetCollection<Produto>(_collectionName);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoCollection.Find(_ => true).ToList();
        }

        public Produto GetById(Guid id)
        {
            return _produtoCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Produto produto)
        {
            _produtoCollection.InsertOne(produto);
        }

        public void Update(Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(x => x.Id, produto.Id);
            _produtoCollection.ReplaceOne(filter, produto);
        }

        public void Delete(Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(x => x.Id, produto.Id);
            _produtoCollection.DeleteOne(filter);
        }
    }
}
