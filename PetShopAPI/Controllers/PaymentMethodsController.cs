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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentMethodsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetById(id);
            if (paymentMethod == null) return NotFound();
            return Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentMethod paymentMethod)
        {
            await _paymentMethodsService.Create(paymentMethod);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentMethod paymentMethod)
        {
            await _paymentMethodsService.Update(paymentMethod);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentMethodsService.Delete(id);
            return Ok();
        }
    }
}
