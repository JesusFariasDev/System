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
        public async Task<ActionResult> GetProductAsync(GetProductRequest? request)
        {
            var response = await _inventoryService.GetProductAsync(request?.Code, request?.Name, request?.MinValue, request?.MaxValue, request?.Category, request?.Disponible, request?.PageSize, request?.PageIndex);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewProductAsync(Product request)
        {
            try
            {
                await _inventoryService.CreateNewProductAsync(request);
                return Created("$Inventory", request);
            }
            catch (Exception ex)
            {
                return BadRequest(new {  ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProductAsync(Product product, string oldCode)
        {
            var newProduct = await _inventoryService.UpdateProductAsync(product, oldCode);

            return Ok(newProduct);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync(string code, string user)
        {
            await _inventoryService.DeleteProductAsync(code, user);

            return NoContent();
        }
    }
}
