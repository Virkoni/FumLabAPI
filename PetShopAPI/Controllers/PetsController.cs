using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _petsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petsService.GetById(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pet pet)
        {
            await _petsService.Create(pet);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pet pet)
        {
            await _petsService.Update(pet);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _petsService.Delete(id);
            return Ok();
        }
    }
}
