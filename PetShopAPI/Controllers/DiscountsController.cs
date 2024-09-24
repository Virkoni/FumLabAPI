using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsService _discountsService;

        public DiscountsController(IDiscountsService discountsService)
        {
            _discountsService = discountsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _discountsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountsService.GetById(id);
            if (discount == null) return NotFound();
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Discount discount)
        {
            await _discountsService.Create(discount);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Discount discount)
        {
            await _discountsService.Update(discount);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountsService.Delete(id);
            return Ok();
        }
    }
}
