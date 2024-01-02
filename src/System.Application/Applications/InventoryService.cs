﻿using System;
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

        public async Task <List<Product>> GetProductAsync(
            string? code = null, string? name = null, decimal? minValue = null, decimal? maxValue = null, string? category = null, bool? disponible = null
            )
        {
            if (minValue != null && maxValue == null) throw new Exception("Please, fill max value for this search.");

            if (maxValue != null && minValue == null) throw new Exception("Please, fill min value for this search.");

            var response = await _productRepository.GetProductAsync(code, name, minValue, maxValue, category, disponible);

            if (response == null)
            {
                throw new Exception("Product not found in our database.");
            }

            return response;
        }

        public async Task CreateNewProductAsync(Product request)
        {
            if (request == null) throw new ArgumentNullException();

            await ChecksProductExistInDatabaseAsync(request.Code);

            ChecksNegativeValues(request.AllQuantity, request.Price, request.ReservedQuantity);

            await _productRepository.WriteProductInDatabaseAsync(request);
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
    }
}