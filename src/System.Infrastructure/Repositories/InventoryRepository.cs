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

namespace System.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly Context.Context _productContext;

        public InventoryRepository(Context.Context productContext)
        {
            _productContext = productContext;
        }
        public async Task<List<Product>> GetProductAsync(
           int pageIndex, int pageSize, string? code, string? productName = null, decimal? minPrice = null, decimal? maxPrice = null, string? category = null, bool? disponible = null
)
        {
            if (pageSize > 0 && pageIndex > 0)
            {
                int productsCount = _productContext.Products.Count();
                int? totalPages = productsCount / pageSize;

                if (pageIndex > totalPages)
                {
                    throw new Exception("Pagination cannot be null.");
                }

                var query = await _productContext.Products.Where(p =>
                    (code != null ? p.Code == code : false) &&
                    (productName != null ? p.ProductName == productName : false) &&
                    (minPrice != null ? p.Price >= minPrice : false) &&
                    (maxPrice != null ? p.Price <= maxPrice : false) &&
                    (category != null ? p.Category == category : false) &&
                    (disponible != null ? p.DisponibleQuantity > 0 : false))
                    .OrderBy(p => p.Code)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return products;
                    /*, totalCount, totalPages;*/
            }
            /*if (code != null)
            {
                var product = await _productContext.Products.FirstOrDefaultAsync(p => p.Code == code);

                if (product == null)
                {
                    throw new ArgumentNullException("Product not found.");
                }

                List<Product> response = new List<Product> { product };

                return response;
            }
            else
            {
                if (pageSize != null && pageIndex != null)
                {
                    int productsCount = _productContext.Products.Count();
                    int? totalPages = productsCount / pageSize;

                    if(pageIndex > totalPages)
                    {
                        throw new Exception("Pagination cannot be null.");
                    }

                    var products = await _productContext.Products
                        .OrderBy(p = p => p.ProductId)
                        .Skip(pageIndex * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
                    return products, totalCount, totalPages;
                }



                return await _productContext.Products.ToListAsync();      

            }*/
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

            _productContext.Products.Remove(getProduct[0]);
            
            await _productContext.SaveChangesAsync();
        }
    }
}
