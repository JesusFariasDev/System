using Microsoft.AspNetCore.Mvc;
using System.Api.Dtos;
using System.Domain.Interfaces.ApplicationInterfaces;
using System.Domain.Models;

namespace System.Api.Controllers
{
    [ApiController]
    [Route("/Inventory")]
    [Produces("application/json")]
    public class InventoryController :ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<Product> GetProductAsync(ProductRequest? request)
        {
            var response = await _inventoryService.GetProductAsync(request?.Code, request?.Name, request?.MinValue, request?.MaxValue, request?.Supplier, request?.Category, request?.Disponible);

            return new Product();
        }
    }
}
