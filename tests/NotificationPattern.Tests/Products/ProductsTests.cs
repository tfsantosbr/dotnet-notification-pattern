using NotificationPattern.Domain.Products;
using Xunit;

namespace NotificationPattern.Tests.Products
{
    public class ProductsTests
    {
        [Fact]
        public void ProductTest()
        {
            var product = new Product(
                ean: "",
                name: "",
                price: 0,
                stock: 0
                );

            Assert.NotNull(product);
        }
    }
}