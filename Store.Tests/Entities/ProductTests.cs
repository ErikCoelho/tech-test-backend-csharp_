using Store.Domain.Entities;
using Store.Domain.Exceptions;

namespace Store.Tests.Entities
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProductException))]
        public void Should_return_exception_when_product_is_invalid()
        {
            new Produto("shoes", -2, 3);
        }

        [TestMethod]
        public void Should_not_return_exception_when_product_is_valid()
        {
            new Produto("t-shirt", 12, 2);
        }
    }
}
