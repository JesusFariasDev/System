using Microsoft.EntityFrameworkCore;
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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ProductContext _productContext;

        public InventoryRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task <List<Product>> GetProductAsync(
            string? code = null, string? name = null, double? minValue = null, double? maxValue = null, string? supplier = null, string? category = null, bool? disponible = null
)
        {
            return await _productContext.Products.ToListAsync();

            
        }
        public async Task <bool> WriteProductInDatabaseAsync(Product product)
        {
            await _productContext.AddRangeAsync(product);

            return true;
        }
        public async Task<bool> ChecksProductExistInDatabaseAsync(string productCode)
        {
            await _productContext.AddRangeAsync(productCode);

            return true;
        }
    }
}
