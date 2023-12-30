﻿using System;
using System.Collections.Generic;
using System.Domain.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.InfrastructureInterfaces
{
    public interface IInventoryRepository
    {
        Task<List<Product>> GetProductAsync(string? code, string? name, double? minValue, double? maxValue, string? category, bool? disponible
);
        Task WriteProductInDatabaseAsync(Product product);
        Task<bool> ChecksProductExistInDatabaseAsync(string productCode);

    }
}
