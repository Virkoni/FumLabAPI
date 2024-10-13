using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
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
        /// <returns></returns>

        // GET api/<CategoriesController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoriesService.GetAll());
        }

        /// <summary>
        /// Получение информации о категории по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<CategoriesController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoriesService.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "categoryName": "string",
        ///       "Description": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категория</param>
        /// <returns></returns>

        // POST api/<CategoriesController>

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoriesService.Create(category);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о категориях
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "categoryId": 1,
        ///       "categoryName": "string",
        ///       "Description": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категория</param>
        /// <returns></returns>

        // PUT api/<CategoriesController>

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoriesService.Update(category);
            return Ok();
        }

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<CategoriesController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriesService.Delete(id);
            return Ok();
        }
    }
}
