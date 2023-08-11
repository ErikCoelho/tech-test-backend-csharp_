using MongoDB.Driver;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Contexts;

namespace Store.Infra.Repositories
{
    public class ProdutoNoSqlRepository : IProdutoRepository
    {
        private readonly IMongoCollection<Produto> _produtoCollection;

        public ProdutoNoSqlRepository(MongoDbContext dbContext)
        {
            _produtoCollection = dbContext.Produtos;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoCollection.Find(_ => true).ToList();
        }

        public Produto GetById(Guid id)
        {
            return _produtoCollection.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Create(Produto produto)
        {
            _produtoCollection.InsertOne(produto);
        }

        public void Update(Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, produto.Id);
            _produtoCollection.ReplaceOne(filter, produto);
        }

        public void Delete(Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, produto.Id);
            _produtoCollection.DeleteOne(filter);
        }
    }
}
