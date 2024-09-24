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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paymentMethod = await _paymentService.GetById(id);
            if (paymentMethod == null) return NotFound();
            return Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Payment payment)
        {
            await _paymentService.Create(payment);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Payment payment)
        {
            await _paymentService.Update(payment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.Delete(id);
            return Ok();
        }
    }
}
