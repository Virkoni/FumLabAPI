using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using FumLabAPI.Contracts.CustomPlushOrders;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomPlushOrdersController : ControllerBase
    {
        private readonly ICustomPlushOrdersService _customPlushOrderService;

        public CustomPlushOrdersController(ICustomPlushOrdersService customPlushOrderService)
        {
            _customPlushOrderService = customPlushOrderService;
        }

        /// <summary>
        /// Получение информации о всех заказах кастомной фумо
        /// </summary>
        /// <returns>Список заказов</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _customPlushOrderService.GetAll();
            return Ok(orders.Adapt<List<GetCustomPlushOrdersResponse>>());
        }

        /// <summary>
        /// Получение информации о конкретном заказе по ID
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns>Информация о заказе</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _customPlushOrderService.GetById(id);
            if (order == null) return NotFound();
            return Ok(order.Adapt<GetCustomPlushOrdersResponse>());
        }

        /// <summary>
        /// Создание нового заказа кастомной фумо
        /// </summary>
        /// <param name="request">Данные для создания заказа</param>
        /// <returns>Созданный заказ</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCustomPlushOrdersRequest request)
        {
            var dto = request.Adapt<CustomPlushOrder>();
            await _customPlushOrderService.Create(dto);
            return Ok(dto.Adapt<GetCustomPlushOrdersResponse>());
        }

        /// <summary>
        /// Обновление информации о заказе кастомной фумо
        /// </summary>
        /// <param name="request">Обновляемые данные заказа</param>
        /// <returns>Обновленный заказ</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetCustomPlushOrdersResponse request)
        {
            var dto = request.Adapt<CustomPlushOrder>();
            await _customPlushOrderService.Update(dto);
            return Ok(dto.Adapt<GetCustomPlushOrdersResponse>());
        }

        /// <summary>
        /// Удаление заказа кастомной фумо
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customPlushOrderService.Delete(id);
            return NoContent();
        }
    }
}
