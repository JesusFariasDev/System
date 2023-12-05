using System;
using System.Collections.Generic;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public bool ChecksProductExistInDatabaseAsync(string productCode)
        {
            bool response = false;

            return response;
        }

    }
}
