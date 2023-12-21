using System;
using System.Collections.Generic;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Domain.Models;
using System.Infrastructure.Context;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task <bool> ChecksProductExistInDatabaseAsync(string productCode)
        {
            await _productContext.AddRangeAsync(productCode);

            return true;
        }
        public async Task <bool> WriteProductInDatabaseAsync(Product product)
        {
            await _productContext.AddRangeAsync(product);

            return true;
        }
    }
}
