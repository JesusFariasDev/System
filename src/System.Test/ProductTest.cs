using FluentAssertions;
using Moq;
using System.Application.Applications;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Domain.Models;
using Xunit;

namespace System.Test
{

    public class ProductTest
    {
        private readonly ProductService sut;
        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();

        public ProductTest()
        {
            sut = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Checks_If_Request_Is_Empt()
        {
            //Act
            var result = await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateNewProductAsync(It.IsAny<Product>()));

            Assert.Equal("Value cannot be null.", result.Message);
        }

        [Fact]
        public async Task Checks_If_Product_Exist_In_Database()
        {
            var request = ReturnNewProduct();

            //Arrange
            _productRepositoryMock.Setup(x => x.ChecksProductExistInDatabaseAsync(It.IsAny<string>())).ReturnsAsync(false);

            var response = await sut.CreateNewProductAsync(request);

            Assert.False(response);
        }
        [Fact]
        public async Task Checks_If_Negative_Value()
        {
            var request = ReturnNewProduct();
        }
        


        // Auxiliary functions
        public Product ReturnNewProduct()
        {
            var response = new Product
            {
                Id = 1
            };

            return response;
        }
    }
}
