using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.PlushPart;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlushPartsController : ControllerBase
    {
        private readonly IPlushPartsService _plushPartsService;

        public PlushPartsController(IPlushPartsService plushPartsService)
        {
            _plushPartsService = plushPartsService;
        }

        /// <summary>
        /// Получение информации о всех частях плюшевых игрушек
        /// </summary>
        /// <returns>Список частей плюшевых игрушек</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plushParts = await _plushPartsService.GetAll();
            return Ok(plushParts.Adapt<List<GetPlushPartResponse>>());
        }

        /// <summary>
        /// Получение информации о части плюшевой игрушки по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация о части плюшевой игрушки</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plushPart = await _plushPartsService.GetById(id);
            if (plushPart == null) return NotFound();
            return Ok(plushPart.Adapt<GetPlushPartResponse>());
        }

        /// <summary>
        /// Создание новой части плюшевой игрушки
        /// </summary>
        /// <param name="request">Данные для создания части</param>
        /// <returns>Созданная часть</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreatePlushPartRequest request)
        {
            var dto = request.Adapt<PlushPart>();
            await _plushPartsService.Create(dto);
            return Ok(dto.Adapt<GetPlushPartResponse>());
        }

        /// <summary>
        /// Обновление информации о части плюшевой игрушки
        /// </summary>
        /// <param name="request">Обновляемые данные о части</param>
        /// <returns>Обновленная часть</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetPlushPartResponse request)
        {
            var dto = request.Adapt<PlushPart>();
            await _plushPartsService.Update(dto);
            return Ok(dto.Adapt<GetPlushPartResponse>());
        }

        /// <summary>
        /// Удаление части плюшевой игрушки
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plushPartsService.Delete(id);
            return NoContent();
        }
    }
}