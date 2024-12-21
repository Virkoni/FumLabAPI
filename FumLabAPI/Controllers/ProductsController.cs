using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.ProductAvailability;
using FumLabAPI.Contracts.Products;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Получение информации о всех товарах
        /// </summary>
        /// <returns>Список товаров</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productsService.GetAll());
        }

        /// <summary>
        /// Получение информации о товаре по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация о товаре</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productsService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Создание нового товара
        /// </summary>
        /// <param name="request">Данные для создания товара</param>
        /// <returns>Созданный товар</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var dto = request.Adapt<Product>();
            await _productsService.Create(dto);
            return Ok(dto);
        }

        /// <summary>
        /// Обновление информации о товаре
        /// </summary>
        /// <param name="request">Обновляемые данные о товаре</param>
        /// <returns>Обновленный товар</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetProductResponse request)
        {
            var dto = request.Adapt<Product>();
            await _productsService.Update(dto);
            return Ok(dto);
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productsService.Delete(id);
            return NoContent();
        }
    }
}