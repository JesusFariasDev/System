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
        Task<PaginatedProducts> GetProductAsync(
            string? code, string? name, decimal? minValue, decimal? maxValue, string? category, bool? disponible, int? pageIndex, int? pageSize
            );
        Task <Product> UpdateProductAsync(Product product, string oldCode);
        Task<bool> DeleteProductAsync(string product, string user);
    }
}
