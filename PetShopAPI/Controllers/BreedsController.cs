using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly IBreedsService _breedsService;

        public BreedsController(IBreedsService breedsService)
        {
            _breedsService = breedsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _breedsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var breed = await _breedsService.GetById(id);
            if (breed == null) return NotFound();
            return Ok(breed);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Breed breed)
        {
            await _breedsService.Create(breed);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Breed breed)
        {
            await _breedsService.Update(breed);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _breedsService.Delete(id);
            return Ok();
        }
    }
}
