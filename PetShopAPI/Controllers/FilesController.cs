using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;

        public FilesController(IFilesService fileService)
        {
            _filesService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var file = await _filesService.GetById(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Domain.Models.File file)
        {
            await _filesService.Create(file);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Domain.Models.File file)
        {
            await _filesService.Update(file);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filesService.Delete(id);
            return Ok();
        }
    }
}
