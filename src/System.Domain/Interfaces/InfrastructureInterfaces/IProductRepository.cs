using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.InfrastructureInterfaces
{
    public interface IProductRepository
    {
        Task<bool>ChecksProductExistInDatabaseAsync(string code);
    }
}
