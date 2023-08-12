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
        private readonly IProdutoRepository _SqlRepository;
        private readonly IProdutoRepository _NoSqlRepository;
        private readonly IProdutoRepository _FileRepository;

        public ProdutoAppServiceTests()
        {
            _SqlRepository = new FakeProdutoRepository();
            _NoSqlRepository = new FakeProdutoRepository();
            _FileRepository = new FakeProdutoRepository();
        }

        [TestMethod]
        public void Should_return_success_when_produto_is_valid()
        {
            var appService = new ProdutoAppService(_SqlRepository, _NoSqlRepository, _FileRepository);

            var produtoViewModel = new ProdutoViewModel
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

            var produtoViewModel = new ProdutoViewModel
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
