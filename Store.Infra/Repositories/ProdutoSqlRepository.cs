using Store.Infra.Contexts;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Store.Infra.Repositories
{
    public class ProdutoSqlRepository : IProdutoRepository
    {
        private readonly SqlDbContext _context;

        public ProdutoSqlRepository(SqlDbContext context)
        {
            _context = context;
        }

        public void Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        public Produto GetById(Guid id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id)!;
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
    }
}
