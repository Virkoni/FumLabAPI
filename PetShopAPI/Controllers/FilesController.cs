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

        /// <summary>
        /// Получение информации о всех файлах
        /// </summary>
        /// <returns></returns>

        // GET api/<FilesController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filesService.GetAll());
        }

        /// <summary>
        /// Получение информации о файле по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<FilesController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var file = await _filesService.GetById(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        /// <summary>
        /// Создание нового файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///      "nameFile": "string",
        ///      "filePath": "string",
        ///      "fileType": "string",
        ///      "uploadedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>

        // POST api/<FilesController>

        [HttpPost]
        public async Task<IActionResult> Add(Domain.Models.File file)
        {
            await _filesService.Create(file);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о файле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///      "nameFile": "string",
        ///      "filePath": "string",
        ///      "fileType": "string",
        ///       "uploadedBy": 0
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>

        // PUT api/<FilesController>

        [HttpPut]
        public async Task<IActionResult> Update(Domain.Models.File file)
        {
            await _filesService.Update(file);
            return Ok();
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<FileController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filesService.Delete(id);
            return Ok();
        }
    }
}
