using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        /// <returns></returns>

        // GET api/<OrdersController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        /// <summary>
        /// Получение информации о заказе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<OrdersController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "userId": 1,
        ///         "totalAmount": decimal,
        ///         "orderDate": "2024-09-19T14:05:14.947Z"
        ///     }
        /// </remarks>
        /// <param name="order">Заказ</param>
        /// <returns></returns>

        // POST api/<OrdersController>

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            await _orderService.Create(order);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о заказе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "orderId": 1,
        ///       "userId": 1,
        ///       "totalAmount": decimal,
        ///       "orderDate": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="order">Заказ</param>
        /// <returns></returns>

        // PUT api/<OrdersController>


        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            await _orderService.Update(order);
            return Ok();
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<OrdersController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return Ok();
        }
    }
}
