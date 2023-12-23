using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.ApplicationInterfaces
{
    public interface IProductService
    {
        Task<bool> CreateNewProductAsync(Product request, bool newProduct);
    }
}
