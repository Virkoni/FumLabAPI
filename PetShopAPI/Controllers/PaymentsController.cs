using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;

        public PaymentsController(IPaymentsService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Получение информации о всех платежах
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentService.GetAll());
        }

        /// <summary>
        /// Получение информации о платежах по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<PaymentsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentService.GetById(id);
            if (paymentMethod == null) return NotFound();
            return Ok(paymentMethod);
        }

        /// <summary>
        /// Создание нового платежа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "orderId": 1,
        ///       "paymentMethodId": 1,
        ///       "amount": decimal,
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentMethod">Платеж</param>
        /// <returns></returns>

        // POST api/<PaymentsController>

        [HttpPost]
        public async Task<IActionResult> Add(Payment payment)
        {
            await _paymentService.Create(payment);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о платеже
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "paymentId": 1,
        ///       "orderId": 1,
        ///       "paymentMethodId": 1,
        ///       "amount": decimal,
        ///       "paymentDate": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentMethod">Платеж</param>
        /// <returns></returns>

        // PUT api/<PaymentsController>

        [HttpPut]
        public async Task<IActionResult> Update(Payment payment)
        {
            await _paymentService.Update(payment);
            return Ok();
        }

        /// <summary>
        /// Удаление платежа
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<PaymentsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.Delete(id);
            return Ok();
        }
    }
}
