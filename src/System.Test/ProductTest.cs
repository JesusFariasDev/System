using FluentAssertions;
using Moq;
using System.Domain.Models;
using Xunit;

namespace System.Test
{
    public class ProductTest
    {
        [Fact]
        public void VerifyIfRequestIsEmpt()
        {
            var result = Assert.Throws<ArgumentException>(() => ProductService.CreateNewProductAsync(It.IsAny<Product>()));
            Assert.Equal("Value cannot be null", result.Message);
        }

        public static class ProductService
        {
            public static string CreateNewProductAsync(Product request)
            {
                if(request == null) throw new ArgumentException("Value cannot be null");

                return "1";
            }
        }
    }
}
