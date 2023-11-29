using System;
using System.Collections.Generic;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Applications
{
    public class ProductApplication : IProductApplication
    {
        public async Task<bool> CreateNewProductAsync(Product request)
        {
            if (request == null) throw new ArgumentException("Value cannot be null");

            bool ThereIsProduct = await CheckIfThisProductIsInInventory(request.Code);

            return true;
        }

        private Task<bool> CheckIfThisProductIsInInventory(string code)
        {
            throw new NotImplementedException();
        }
    }
}
