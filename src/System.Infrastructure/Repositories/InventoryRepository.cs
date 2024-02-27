using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Domain.Models;
using System.Infrastructure.Context;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace System.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly Context.Context _productContext;

        public InventoryRepository(Context.Context productContext)
        {
            _productContext = productContext;
        }
        public async Task<PaginatedProducts> GetProductAsync(
           string? code, string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, string? category = null, bool? disponible = null, int? pageIndex = null, int? pageSize = null
)
        {
            var query = _productContext.Products
                .AsQueryable()
                .AsNoTracking()
                .Where(p =>
                (code != null ? p.Code.StartsWith(code) : true) &&
                (productName != null ? p.ProductName.Contains(productName) : true) &&
                (minPrice != null ? p.Price >= minPrice : true) &&
                (maxPrice != null ? p.Price <= maxPrice : true) &&
                (category != null ? p.Category == category : true) &&
                (disponible != null && disponible == true ? p.DisponibleQuantity > 0 : true) &&
                (disponible != null && disponible == false ? p.DisponibleQuantity < 1 : true));


            var productsCount = await query.CountAsync();
            int totalPages = productsCount / pageSize.Value;
            bool hasLeftOver = productsCount % pageSize.Value != 0;
            if (hasLeftOver)
            {
                totalPages++;
            }

            var products = await query.OrderBy(p => p.Code)
                .Skip(productsCount > pageSize.Value ? pageIndex.Value * pageSize.Value : 0)
                .Take(pageSize.Value)
                .ToListAsync();

            return new PaginatedProducts { ProductsCount = productsCount, TotalPages = totalPages, Products = products };
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

        public async Task DeleteProductAsync(string product)
        {
            var getProduct = await GetProductAsync(product);

            _productContext.Products.Remove(getProduct.Products[0]);
            
            await _productContext.SaveChangesAsync();
        }
    }
}
