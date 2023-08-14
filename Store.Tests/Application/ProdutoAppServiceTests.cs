using Store.Api.Application;
using Store.Api.ViewModels;
using Store.Domain.Entities;
using Store.Domain.Exceptions;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

namespace Store.Tests.Application
{
    [TestClass]
    public class ProdutoAppServiceTests
    {
        private readonly IProdutoSqlRepository _SqlRepository;
        private readonly IProdutoNoSqlRepository _NoSqlRepository;
        private readonly IProdutoFileRepository _FileRepository;

        public ProdutoAppServiceTests()
        {
            _SqlRepository = new FakeProdutoSqlRepository();
            _NoSqlRepository = new FakeProdutoNoSqlRepository();
            _FileRepository = new FakeProdutoFileRepository();
        }

        [TestMethod]
        public void Should_return_success_when_produto_is_valid()
        {
            var appService = new ProdutoAppService(_SqlRepository, _NoSqlRepository, _FileRepository);

            var produtoViewModel = new EditProdutoViewModel
            {
                Nome = "Shoes",
                Preco = 200,
                QuantidadeEstoque = 10
            };

            var result = appService.Create(produtoViewModel);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void Should_not_return_success_when_produto_is_invalid()
        {
            var appService = new ProdutoAppService(_SqlRepository, _NoSqlRepository, _FileRepository);

            var produtoViewModel = new EditProdutoViewModel
            {
                Nome = "Shoes",
                Preco = -20,
                QuantidadeEstoque = 10
            };

            var result = appService.Create(produtoViewModel);
            Assert.IsFalse(result.Success);
        }
    }
}
