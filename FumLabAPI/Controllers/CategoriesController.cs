using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Categories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        /// <summary>
        /// Получение информации о всех категориях
        /// </summary>
        /// <returns>Список категорий</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoriesService.GetAll();
            return Ok(categories.Adapt<List<GetCategoryResponse>>());
        }

        /// <summary>
        /// Получение информации о категории по id
        /// </summary>
        /// <param name="id">ID категории</param>
        /// <returns>Информация о категории</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoriesService.GetById(id);
            if (category == null) return NotFound();
            return Ok(category.Adapt<GetCategoryResponse>());
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <param name="request">Данные для создания категории</param>
        /// <returns>Созданная категория</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryRequest request)
        {
            var dto = request.Adapt<Category>();
            await _categoriesService.Create(dto);
            return Ok(dto.Adapt<GetCategoryResponse>());
        }

        /// <summary>
        /// Обновление информации о категории
        /// </summary>
        /// <param name="request">Обновляемые данные категории</param>
        /// <returns>Обновленная категория</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetCategoryResponse request)
        {
            var dto = request.Adapt<Category>();
            await _categoriesService.Update(dto);
            return Ok(dto.Adapt<GetCategoryResponse>());
        }

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id">ID категории</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriesService.Delete(id);
            return NoContent();
        }
    }
}