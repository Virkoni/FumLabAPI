using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
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
        /// <returns></returns>

        // GET api/<InventoryController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _inventoryService.GetAll());
        }

        /// <summary>
        /// Получение информации о инвентаре по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<InventoryController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _inventoryService.GetById(id);
            if (inventory == null) return NotFound();
            return Ok(inventory);
        }

        /// <summary>
        /// Создание нового инвентаря
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "productId" : 1,
        ///        "quantity" : 3,
        ///     }
        ///
        /// </remarks>
        /// <param name="inventory">Инвентарь</param>
        /// <returns></returns>

        // POST api/<InventoryController>

        [HttpPost]
        public async Task<IActionResult> Add(Inventory inventory)
        {
            await _inventoryService.Create(inventory);
            return Ok();
        }

        /// <summary>
        /// Изменение информации об инвентаре
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "productId" : 1,
        ///        "quantity" : 3,
        ///        "lastUpdated": "2024-09-19T14:05:14.947Z",
        ///        "isDeleted": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="inventory">Инвентарь</param>
        /// <returns></returns>

        // PUT api/<InventoryController>

        [HttpPut]
        public async Task<IActionResult> Update(Inventory inventory)
        {
            await _inventoryService.Update(inventory);
            return Ok();
        }

        /// <summary>
        /// Удаление инвентаря
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<InventoryController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryService.Delete(id);
            return Ok();
        }
    }
}
