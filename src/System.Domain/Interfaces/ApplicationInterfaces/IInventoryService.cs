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
        Task<bool> CreateNewProductAsync(Product request);
        Task<Product> GetProductAsync(string? code, string? name);
    }
}
