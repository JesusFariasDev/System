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
    public class InventoryRepository : Domain.Interfaces.InfrastructureInterfaces.IInventoryRepository
    {
        private readonly ProductContext _productContext;

        public InventoryRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task <Product> GetProductAsync(string productCode)
        {
            await _productContext.AddRangeAsync(productCode);

            return new Product();
        }
        public async Task <bool> WriteProductInDatabaseAsync(Product product)
        {
            await _productContext.AddRangeAsync(product);

            return true;
        }
    }
}
