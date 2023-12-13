using System;
using System.Collections.Generic;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Interfaces.InfrastructureInterfaces;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Applications
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CreateNewProductAsync(Product request)
        {
            if (request == null) throw new ArgumentNullException();

            bool ThereIsProduct = await ChecksProductExistInDatabaseAsync(request.Code);

            return ThereIsProduct;
        }
        public async Task<bool> ChecksProductExistInDatabaseAsync(string productCode)
        {
            bool response = await _productRepository.ChecksProductExistInDatabaseAsync(productCode);

            return response;
        }
    }
}
