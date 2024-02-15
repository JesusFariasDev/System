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
        Task<List<Product>> GetProductAsync(string? code, string? name, decimal? minValue, decimal? maxValue, string? category, bool? disponible, int? pageNumber = null, int? pageSize = null
);
        Task WriteProductInDatabaseAsync(Product product);
        Task<bool> ChecksProductExistInDatabaseAsync(string productCode);
        Task UpdateProductAsync(Product product, Product oldProduct);
        Task DeleteProductAsync(string product);
    }
}
