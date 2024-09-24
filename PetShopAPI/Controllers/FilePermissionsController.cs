using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilePermissionsController : ControllerBase
    {
        private readonly IFilePermissionsService _filePermissionsService;

        public FilePermissionsController(IFilePermissionsService filePermissions)
        {
            _filePermissionsService = filePermissions;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filePermissionsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filePermission = await _filePermissionsService.GetById(id);
            if (filePermission == null) return NotFound();
            return Ok(filePermission);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FilePermission filePermission)
        {
            await _filePermissionsService.Create(filePermission);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(FilePermission filePermission)
        {
            await _filePermissionsService.Update(filePermission);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filePermissionsService.Delete(id);
            return Ok();
        }
    }
}
