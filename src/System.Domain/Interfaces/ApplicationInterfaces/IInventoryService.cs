using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.ApplicationInterfaces
{
    public interface IInventoryService
    {
        Task CreateNewProductAsync(Product product);
        Task<List<Product>> GetProductAsync(
            string? code, string? name, decimal? minValue, decimal? maxValue, string? category, bool? disponible
            );
        Task <Product>UpdateProductAsync(Product product, string oldCode);
    }
}
