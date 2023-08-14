using Store.Api.ViewModels;
using Store.Domain.Entities;
using Store.Domain.Exceptions;
using Store.Domain.Repositories;

namespace Store.Api.Application
{
    public class ProdutoAppService
    {
        private readonly IProdutoSqlRepository _sqlProdutoRepository;
        private readonly IProdutoNoSqlRepository _nosqlProdutoRepository;
        private readonly IProdutoFileRepository _fileProdutoRepository;

        public ProdutoAppService(
            IProdutoSqlRepository sqlProdutoRepository,
            IProdutoNoSqlRepository nosqlProdutoRepository,
            IProdutoFileRepository fileProdutoRepository)
        {
            _sqlProdutoRepository = sqlProdutoRepository;
            _nosqlProdutoRepository = nosqlProdutoRepository;
            _fileProdutoRepository = fileProdutoRepository;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _fileProdutoRepository.GetAll();
        }

        public Produto GetById(Guid id)
        {
            return _fileProdutoRepository.GetById(id);
        }

        public ResultViewModel Create(EditProdutoViewModel produto)
        {
            try 
            { 
                var produto_ = new Produto(produto.Nome, produto.Preco, produto.QuantidadeEstoque);

                CreateProdutoInAllRepositories(produto_);

                return new ResultViewModel(true, $"Produto {produto_.Id} foi criado com sucesso", produto_);

            }
            catch (InvalidProductException ex)
            {
                return new ResultViewModel(false, ex.Message, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultViewModel(false, ex.Message, string.Empty);
            }
        }

        public ResultViewModel Update(Guid id, EditProdutoViewModel produto)
        {
            var produto_ = _fileProdutoRepository.GetById(id);

            if (produto_ == null)
            {
                return new ResultViewModel(false, "Produto não encontrado", string.Empty);
            }

            try
            {
                produto_.ProdutoUpdate(produto.Nome, produto.Preco, produto.QuantidadeEstoque);

                UpdateProdutoInAllRepositories(produto_);

                return new ResultViewModel(true, $"Produto {produto_.Id} atualizado com sucesso", produto_);
            }
            catch (InvalidProductException ex)
            {
                return new ResultViewModel(false, ex.Message, string.Empty);
            }
            catch (Exception)
            {
                return new ResultViewModel(false, "P8tw - Falha interna no servidor", string.Empty);
            }
            
        }

        public ResultViewModel Delete(Guid id)
        {
            var produto = _fileProdutoRepository.GetById(id);

            if (produto == null)
            {
                return new ResultViewModel(false, "Produto não encontrado", string.Empty);
            }

            try
            {
                DeleteProdutoFromAllRepositories(produto);

                return new ResultViewModel(true, $"Produto {produto.Id} deletado com sucesso", produto);
            }
            catch (Exception)
            {
                return new ResultViewModel(false, "8kdn - Falha interna no servidor", string.Empty);
            }
        }
        private void CreateProdutoInAllRepositories(Produto produto)
        {
            _fileProdutoRepository.Create(produto);
            _sqlProdutoRepository.Create(produto);
            _nosqlProdutoRepository.Create(produto);
        }

        private void UpdateProdutoInAllRepositories(Produto produto)
        {
            _sqlProdutoRepository.Update(produto);
            _fileProdutoRepository.Update(produto);
            _nosqlProdutoRepository.Update(produto);
        }

        private void DeleteProdutoFromAllRepositories(Produto produto)
        {
            _sqlProdutoRepository.Delete(produto);
            _fileProdutoRepository.Delete(produto);
            _nosqlProdutoRepository.Delete(produto);
        }
    }
}