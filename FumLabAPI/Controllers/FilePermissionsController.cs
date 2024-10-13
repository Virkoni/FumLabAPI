using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FumLabAPI.Controllers
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

        /// <summary>
        /// Получение информации о всех разрешениях
        /// </summary>
        /// <returns></returns>

        // GET api/<FilePermissionsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filePermissionsService.GetAll());
        }

        /// <summary>
        /// Получение информации о разрешениях по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<FilePermissionsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filePermission = await _filePermissionsService.GetById(id);
            if (filePermission == null) return NotFound();
            return Ok(filePermission);
        }

        /// <summary>
        /// Создание нового разрешения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///      "fileId": 1,
        ///      "roleId": ,
        ///       "canView": 0,
        ///       "canEdit": 0,
        ///       "canDelete": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="filePermission">Разрешение</param>
        /// <returns></returns>

        // POST api/<FilePermissionsController>

        [HttpPost]
        public async Task<IActionResult> Add(FilePermission filePermission)
        {
            await _filePermissionsService.Create(filePermission);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о разрешении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///      "permissionId": "string",
        ///      "fileId": 1,
        ///      "roleId": ,
        ///       "canView": 0,
        ///       "canEdit": 0,
        ///       "canDelete": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="filePermission">Разрешение</param>
        /// <returns></returns>

        // PUT api/<FilePermissionsController>

        [HttpPut]
        public async Task<IActionResult> Update(FilePermission filePermission)
        {
            await _filePermissionsService.Update(filePermission);
            return Ok();
        }

        /// <summary>
        /// Удаление разрешения
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<FilePermissionsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filePermissionsService.Delete(id);
            return Ok();
        }
    }
}
