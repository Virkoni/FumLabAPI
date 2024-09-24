using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountUsageController : ControllerBase
    {
        private readonly IDiscountUsageService _discountUsageService;

        public DiscountUsageController(IDiscountUsageService discountUsageService)
        {
            _discountUsageService = discountUsageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _discountUsageService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discountUsage = await _discountUsageService.GetById(id);
            if (discountUsage == null) return NotFound();
            return Ok(discountUsage);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DiscountUsage discountUsage)
        {
            await _discountUsageService.Create(discountUsage);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(DiscountUsage discountUsage)
        {
            await _discountUsageService.Update(discountUsage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountUsageService.Delete(id);
            return Ok();
        }
    }
}
