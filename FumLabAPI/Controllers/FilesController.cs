using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.File;
using FumLabAPI.Contracts.Roles;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        /// <summary>
        /// Получение информации о всех файлах
        /// </summary>
        /// <returns>Список файлов</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var files = await _filesService.GetAll();
            return Ok(files.Adapt<List<GetFileResponse>>());
        }

        /// <summary>
        /// Получение информации о файле по id
        /// </summary>
        /// <param name="id">ID файла</param>
        /// <returns>Информация о файле</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var file = await _filesService.GetById(id);
            if (file == null) return NotFound();
            return Ok(file.Adapt<GetFileResponse>());
        }

        /// <summary>
        /// Загрузка нового файла
        /// </summary>
        /// <param name="request">Запрос с данными файла</param>
        /// <returns>Загруженный файл</returns>

        [HttpPost]
        public async Task<IActionResult> Upload(CreateFileRequest request)
        {
            var dto = request.Adapt<Domain.Models.File>();
            await _filesService.Update(dto);
            return Ok(dto.Adapt<GetFileResponse>());
        }

        /// <summary>
        /// Обновление информации о файле
        /// </summary>
        /// <param name="request">Обновляемые данные файла</param>
        /// <returns>Обновленный файл</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetFileResponse request)
        {
            var dto = request.Adapt<Domain.Models.File>();
            await _filesService.Update(dto);
            return Ok(dto.Adapt<GetFileResponse>());
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="id">ID файла</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _filesService.Delete(id);
            return NoContent();
        }
    }
}