using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.PlushPartCategories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlushPartCategoriesController : ControllerBase
    {
        private readonly IPlushPartCategoriesService _plushPartCategoriesService;

        public PlushPartCategoriesController(IPlushPartCategoriesService plushPartCategoriesService)
        {
            _plushPartCategoriesService = plushPartCategoriesService;
        }

        /// <summary>
        /// Получение информации о всех категориях частей плюшевых игрушек
        /// </summary>
        /// <returns>Список категорий частей плюшевых игрушек</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _plushPartCategoriesService.GetAll();
            return Ok(categories.Adapt<List<GetPlushPartCategoriesResponse>>());
        }

        /// <summary>
        /// Получение информации о категории частей плюшевой игрушки по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация о категории частей плюшевой игрушки</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _plushPartCategoriesService.GetById(id);
            if (category == null) return NotFound();
            return Ok(category.Adapt<GetPlushPartCategoriesResponse>());
        }

        /// <summary>
        /// Создание новой категории частей плюшевой игрушки
        /// </summary>
        /// <param name="request">Данные для создания категории</param>
        /// <returns>Созданная категория</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreatePlushPartCategoriesRequest request)
        {
            var dto = request.Adapt<PlushPartCategory>();
            await _plushPartCategoriesService.Create(dto);
            return Ok(dto.Adapt<GetPlushPartCategoriesResponse>());
        }

        /// <summary>
        /// Обновление информации о категории частей плюшевой игрушки
        /// </summary>
        /// <param name="request">Обновляемые данные о категории</param>
        /// <returns>Обновленная категория</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetPlushPartCategoriesResponse request)
        {
            var dto = request.Adapt<PlushPartCategory>();
            await _plushPartCategoriesService.Update(dto);
            return Ok(dto.Adapt<GetPlushPartCategoriesResponse>());
        }

        /// <summary>
        /// Удаление категории частей плюшевой игрушки
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plushPartCategoriesService.Delete(id);
            return NoContent();
        }
    }
}