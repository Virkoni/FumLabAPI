using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSuppliersController : ControllerBase
    {
        private readonly IProductSuppliersService _productSuppliersService;

        public ProductSuppliersController(IProductSuppliersService productSuppliersService)
        {
            _productSuppliersService = productSuppliersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productSuppliersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productSupplier = await _productSuppliersService.GetById(id);
            if (productSupplier == null) return NotFound();
            return Ok(productSupplier);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductsSupplier productSupplier)
        {
            await _productSuppliersService.Create(productSupplier);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductsSupplier productSupplier)
        {
            await _productSuppliersService.Update(productSupplier);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productSuppliersService.Delete(id);
            return Ok();
        }
    }
}
