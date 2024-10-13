using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodsService _paymentMethodsService;

        public PaymentMethodsController(IPaymentMethodsService paymentMethodsService)
        {
            _paymentMethodsService = paymentMethodsService;
        }

        /// <summary>
        /// Получение информации о всех способах платежа
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentMethodsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentMethodsService.GetAll());
        }

        /// <summary>
        /// Получение информации о способах платежа по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<PaymentMethodsController>


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetById(id);
            if (paymentMethod == null) return NotFound();
            return Ok(paymentMethod);
        }

        /// <summary>
        /// Создание нового способа платежа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "methodName": "string",
        ///       "description": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentMethod">Cпособ платежа</param>
        /// <returns></returns>

        // POST api/<PaymentMethodsController>

        [HttpPost]
        public async Task<IActionResult> Add(PaymentMethod paymentMethod)
        {
            await _paymentMethodsService.Create(paymentMethod);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о способах платежа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "paymentMethodId": 1,
        ///       "methodName": "string",
        ///       "description": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentMethod">Cпособ платежая</param>
        /// <returns></returns>

        // PUT api/<PaymentMethodsController>

        [HttpPut]
        public async Task<IActionResult> Update(PaymentMethod paymentMethod)
        {
            await _paymentMethodsService.Update(paymentMethod);
            return Ok();
        }

        /// <summary>
        /// Удаление способа платежа
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<PaymentMethodsController>


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentMethodsService.Delete(id);
            return Ok();
        }
    }
}
