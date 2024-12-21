using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Payment;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FumLabAPI.Controllers
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
        /// Получение информации о всех платежей
        /// </summary>
        /// <returns>Список платежей</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.GetAll();
            return Ok(payments.Adapt<List<GetPaymentResponse>>());
        }

        /// <summary>
        /// Получение информации о платеже по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация об платеже</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentService.GetById(id);
            if (paymentMethod == null) return NotFound();
            return Ok(paymentMethod.Adapt<GetPaymentResponse>());
        }

        /// <summary>
        /// Создание нового платежа
        /// </summary>
        /// <param name="request">Данные для создания платежа</param>
        /// <returns>Созданный платеж</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreatePaymentRequest request)
        {
            var dto = request.Adapt<Payment>();
            await _paymentService.Create(dto);
            return Ok(dto.Adapt<GetPaymentResponse>());
        }

        /// <summary>
        /// Обновление информации о платеже
        /// </summary>
        /// <param name="request">Обновляемые данные о платеже</param>
        /// <returns>Обновленный платеж</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetPaymentResponse request)
        {
            var dto = request.Adapt<Payment>();
            await _paymentService.Update(dto);
            return Ok(dto.Adapt<GetPaymentResponse>());
        }

        /// <summary>
        /// Удаление платежа
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.Delete(id);
            return NoContent();
        }
    }
}