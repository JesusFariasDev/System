using FluentAssertions;
using Moq;
using System.Application.Applications;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Models;
using Xunit;

namespace System.Test
{

    public class ProductTest
    {
        private readonly ProductApplication sut;
        private readonly Mock<IProductApplication> _productApplicationMock = new Mock<IProductApplication>();

        public ProductTest()
        {
            sut = new ProductApplication();
        }

        [Fact]
        public async Task VerifyIfRequestIsEmpt()
        {
            //Act
            var result = await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateNewProductAsync(It.IsAny<Product>()));

            Assert.Equal("Value cannot be null.", result.Message);
        }


        public static Mock<IProductApplication>CallInterfaces()
        {
            var _productApplication = new Mock<IProductApplication>();

            return _productApplication;
        }
    }
}
