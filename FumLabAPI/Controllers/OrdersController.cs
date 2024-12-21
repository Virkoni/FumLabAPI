using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Orders;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Получение информации о всех заказах
        /// </summary>
        /// <returns>Список заказов</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders.Adapt<List<GetOrderResponse>>());
        }

        /// <summary>
        /// Получение информации о заказе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация об заказе</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null) return NotFound();
            return Ok(order.Adapt<GetOrderResponse>());
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="request">Данные для создания заказа</param>
        /// <returns>Созданный заказ</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {
            var dto = request.Adapt<Order>();
            await _orderService.Create(dto);
            return Ok(dto.Adapt<GetOrderResponse>());
        }

        /// <summary>
        /// Обновление информации о заказе
        /// </summary>
        /// <param name="request">Обновляемые данные о заказе</param>
        /// <returns>Обновленный заказ</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetOrderResponse request)
        {
            var dto = request.Adapt<Order>();
            await _orderService.Update(dto);
            return Ok(dto.Adapt<GetOrderResponse>());
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return NoContent();
        }
    }
}