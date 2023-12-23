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
            bool response;
            if (request == null) throw new ArgumentNullException();

            var ThereIsProduct = await ChecksProductExistInDatabaseAsync(request.Code, true);

            bool negativeValues = await ChecksNegativeValues(request.AllQuantity, request.Price, request.ReservedQuantity);

            bool writeProductInDatabase = await _productRepository.WriteProductInDatabaseAsync(request);

            if (writeProductInDatabase && !negativeValues)
            {
                response = true;
            }
            else
            {
                response = false;
            }

            return response;
        }


        public async Task<Product> ChecksProductExistInDatabaseAsync(string productCode, bool newProduct)
        {
            var response = await _productRepository.GetProductAsync(productCode);

            if (newProduct && response != null)
            {
                throw new Exception("Product already exists in our database");
            }

            else if (!newProduct && response == null)
            {
                throw new Exception("Product not found in our database.");
            }

            return response;
        }

        public async Task<bool> ChecksNegativeValues(double allQuantity, double price, double reservedQuantity)
        {
            if (allQuantity < 0)
            {
                throw new Exception("Quantity cannot be less than 0.");
            }
            if (price < 0)
            {
                throw new Exception("Price cannot be less than 0.");

            }
            if (reservedQuantity < 0)
            {
                throw new Exception("Reserved quantity cannot be less than 0.");
            }

            return false;
        }
    }
}
