using FluentAssertions;
using Moq;
using System.Application.Applications;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Domain.Models;
using System.Infrastructure.Repositories;
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
            var request = ReturnNewProduct(null);

            //Arrange
            _productRepositoryMock.Setup(x => x.ChecksProductExistInDatabaseAsync(It.IsAny<string>())).ReturnsAsync(false);

            var response = await sut.CreateNewProductAsync(request);

            Assert.False(response);
        }
        [Fact]
        public async Task Checks_If_Negative_All_Quantity()
        {
            var request = ReturnNewProduct("allQuantity");

            var result = await Assert.ThrowsAsync<Exception>(() => sut.CreateNewProductAsync(request));

            Assert.Equal("Quantity cannot be less than 0.", result.Message);
        }

        [Fact]
        public async Task Checks_If_Negative_Price()
        {
            var request = ReturnNewProduct("price");

            var result = await Assert.ThrowsAsync<Exception>(() => sut.CreateNewProductAsync(request));

            Assert.Equal("Price cannot be less than 0.", result.Message);
        }
        [Fact]
        public async Task Checks_If_Negative_Reserved_Quantity()
        {
            var request = ReturnNewProduct("reservedQuantity");

            var result = await Assert.ThrowsAsync<Exception>(() => sut.CreateNewProductAsync(request));

            Assert.Equal("Reserved quantity cannot be less than 0.", result.Message);
        }


        // Auxiliary functions
        public Product ReturnNewProduct(string? parameter)
        {
            var response = new Product();

            switch(parameter)
            {
                case "allQuantity":
                    response.AllQuantity = -1;
                    break;

                case "price":
                    response.Price = -1;
                    break;

                case "reservedQuantity":
                    response.ReservedQuantity = -1; 
                    break;

                default:
                    response.AllQuantity = 1;
                    break;
            }

            return response;

        }
    }
}
