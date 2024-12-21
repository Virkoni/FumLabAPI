using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Inventory;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Получение информации о всем инвентаре
        /// </summary>
        /// <returns>Список товаров</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _inventoryService.GetAll();
            return Ok(inventories.Adapt<List<GetInventoryResponse>>());
        }

        /// <summary>
        /// Получение информации о инвентаре по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация об инвентаре</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _inventoryService.GetById(id);
            if (inventory == null) return NotFound();
            return Ok(inventory.Adapt<GetInventoryResponse>());
        }

        /// <summary>
        /// Создание нового инвентаря
        /// </summary>
        /// <param name="request">Данные для создания инвентаря</param>
        /// <returns>Созданный инвентарь</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateInventoryRequest request)
        {
            var dto = request.Adapt<Inventory>();
            await _inventoryService.Create(dto);
            return Ok(dto.Adapt<GetInventoryResponse>());
        }

        /// <summary>
        /// Обновление информации об инвентаре
        /// </summary>
        /// <param name="request">Обновляемые данные инвентаря</param>
        /// <returns>Обновленный инвентарь</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetInventoryResponse request)
        {
            var dto = request.Adapt<Inventory>();
            await _inventoryService.Update(dto);
            return Ok(dto.Adapt<GetInventoryResponse>());
        }

        /// <summary>
        /// Удаление инвентаря
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryService.Delete(id);
            return NoContent();
        }
    }
}