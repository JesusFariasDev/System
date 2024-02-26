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
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _productRepository;

        public InventoryService(IInventoryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task <PaginatedProducts> GetProductAsync(
            string? code = null, string? name = null, decimal? minValue = null, decimal? maxValue = null, string? category = null, bool? disponible = null, int? pageIndex = 1, int? pageSize = 20
            )
        {
            if (minValue != null && maxValue == null) throw new Exception("Please, fill max value for this search.");

            if (maxValue != null && minValue == null) throw new Exception("Please, fill min value for this search.");

            if (pageIndex == null) {  pageIndex = 0; }

            if (pageSize == null) {  pageSize = 20; }

            var response = await _productRepository.GetProductAsync(code, name, minValue, maxValue, category, disponible, pageIndex, pageSize);

            if (response == null)
            {
                throw new Exception("Product not found in our database.");
            }

            return response;
        }

        public async Task CreateNewProductAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException();

            await ChecksProductExistInDatabaseAsync(product.Code);

            ChecksNegativeValues(product.AllQuantity, product.Price, product.ReservedQuantity);

            await _productRepository.WriteProductInDatabaseAsync(product);
        }
        public async Task ChecksProductExistInDatabaseAsync(string productCode)
        {
            bool response = await _productRepository.ChecksProductExistInDatabaseAsync(productCode);

            if (response)
            {
                throw new Exception("Product already exists in our database");
            }
        }

        public void ChecksNegativeValues(decimal? allQuantity, decimal? price, decimal? reservedQuantity)
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
        }

        public async Task<Product> UpdateProductAsync(Product product, string oldCode)
        {
            var oldProduct = await GetProductAsync(oldCode);

            FillTheField(product);

            if (oldProduct.Products == null) 
            {
                throw new Exception("Product not found in our database.");
            }

            try
            {
                await _productRepository.UpdateProductAsync(product, oldProduct.Products[0]);
                return product;
            }
            catch
            {
                throw new Exception("Product has not been updated.");
            }
        }

        public void FillTheField<T>(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Please fill the fields.");
            }

            var properties = typeof(T).GetProperties();
            var nullPropertie = properties.FirstOrDefault(p => p.GetValue(data) == null);

            if(nullPropertie != null)
            {
                throw new ArgumentNullException(nullPropertie.Name, $"{nullPropertie.Name} cannot be null.");
            }
        }
        public async Task<bool> DeleteProductAsync(string code, string user)
        {
            if (code == null || user == null)
            {
                throw new ArgumentNullException("Please fill the fields.");
            }
            await _productRepository.DeleteProductAsync(code);

            return true;
        }
    }
}
