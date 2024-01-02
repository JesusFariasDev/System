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
            string? code = null, string? name = null, decimal? minValue = null, decimal? maxValue = null, string? category = null, bool? disponible = null
)
        {
            return await _productContext.Products.ToListAsync();

            
        }
        public async Task WriteProductInDatabaseAsync(Product product)
        {
            await _productContext.Products.AddAsync(new Product
            {
                Code = product.Code,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Category = product.Category,
                AllQuantity = product.AllQuantity,
                DisponibleQuantity = product.DisponibleQuantity,
                ReservedQuantity = product.ReservedQuantity,
                PurchasePrice = product.PurchasePrice,
                DateOfPurchase = product.DateOfPurchase,
                Price = product.Price,
                TaxValue = product.TaxValue,
                ProfitMargin = product.ProfitMargin
            });

            await _productContext.SaveChangesAsync();
        }
        public async Task<bool> ChecksProductExistInDatabaseAsync(string productCode)
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(p => p.Code == productCode);

            var response = (product == null) ? false : true;

            return response;
        }
    }
}
