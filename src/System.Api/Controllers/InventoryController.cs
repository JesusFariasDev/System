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
        public async Task<List<Product>> GetProductAsync(GetProductRequest? request)
        {
            var response = await _inventoryService.GetProductAsync(request?.Code, request?.Name, request?.MinValue, request?.MaxValue, request?.Supplier, request?.Category, request?.Disponible);

            return response;
        }

        [HttpPost]
        public async Task<bool> CreateNewProductAsync(Product request)
        {
            bool response = await _inventoryService.CreateNewProductAsync(request);

            return response;
        }
    }
}
