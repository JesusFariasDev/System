using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.InfrastructureInterfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(string code);
        Task<bool> WriteProductInDatabaseAsync(Product product);

    }
}
