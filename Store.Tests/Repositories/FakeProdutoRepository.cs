using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeProdutoRepository : IProdutoRepository
    {
        public void Create(Produto produto)
        {
            
        }

        public void Delete(Produto produto)
        {
            
        }

        public IEnumerable<Produto> GetAll()
        {
            List<Produto> _produtos = new List<Produto>
            {
                new Produto("Shoes", 130, 3),
                new Produto("T-shirt", 27, 20),
                new Produto("TV", 1000, 4),
                new Produto("Mouse", 20, 14)
            };
            return _produtos;
        }

        public Produto GetById(Guid id)
        {
            return new Produto("Shoes", 130, 3);
        }

        public void Update(Produto produto)
        {

        }
    }
}
