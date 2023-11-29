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
        [Fact]
        public void VerifyIfRequestIsEmpt()
        {
            var result = Assert.Throws<ArgumentException>(() => ProductApplication.CreateNewProductAsync(It.IsAny<Product>()));
            Assert.Equal("Value cannot be null", result.Message);
        }


       
    }
}
