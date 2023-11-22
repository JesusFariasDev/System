using System.Domain.Models;
using Xunit;

namespace System.Test
{
    public class ProductTest
    {
        [Fact]
        public void VerifyIfRequestIsEmpt()
        {
            var request = new Product();

            string result = ProductService.CreateNewProductAsync(request);

            Assert.Empty(result);

            Assert.Throws<ArgumentException>(() => ProductService.CreateNewProductAsync(null));
            Assert.ThrowsAny<Exception>(() => ProductService.CreateNewProductAsync(request));
        }

        public static class ProductService
        {
            public static string CreateNewProductAsync(Product request)
            {
                if (request == null)
                {
                    throw new ArgumentException("Value cannot be null");
                }

                return string.Empty;
            }
        }
    }
}
