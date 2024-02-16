using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.InfrastructureInterfaces
{
    public interface IInventoryRepository
    {
        Task<PaginatedProducts> GetProductAsync(string? code, string? name, decimal? minValue, decimal? maxValue, string? category, bool? disponible, int? pageIndex, int? pageSize
);
        Task WriteProductInDatabaseAsync(Product product);
        Task<bool> ChecksProductExistInDatabaseAsync(string productCode);
        Task UpdateProductAsync(Product product, Product oldProduct);
        Task DeleteProductAsync(string product);
    }
}
