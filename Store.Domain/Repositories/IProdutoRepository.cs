using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(Guid id);
        void Create(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
    }
}