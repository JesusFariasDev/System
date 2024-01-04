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
            await _productContext.Products.AddAsync(product);

            await _productContext.SaveChangesAsync();
        }
        public async Task<bool> ChecksProductExistInDatabaseAsync(string productCode)
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(p => p.Code == productCode);

            var response = (product == null) ? false : true;

            return response;
        }

        public async Task UpdateProductAsync(Product product, Product oldProduct)
        {
            oldProduct.Code = product.Code;
            oldProduct.ProductName = product.ProductName;
            oldProduct.ProductDescription = product.ProductDescription;
            oldProduct.Category = product.Category;
            oldProduct.AllQuantity = product.AllQuantity;
            oldProduct.DisponibleQuantity = product.DisponibleQuantity;
            oldProduct.ReservedQuantity = product.ReservedQuantity;
            oldProduct.PurchasePrice = product.PurchasePrice;
            oldProduct.DateOfPurchase = product.DateOfPurchase;
            oldProduct.Price = product.Price;
            oldProduct.TaxValue = product.TaxValue;
            oldProduct.ProfitMargin = product.ProfitMargin;

            _productContext.Products.Update(oldProduct);
            await _productContext.SaveChangesAsync();
        }
    }
}
