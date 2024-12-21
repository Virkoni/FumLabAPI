using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.ProductAvailability;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAvailabilitiesController : ControllerBase
    {
        private readonly IProductAvailabilityService _productAvailabilityService;

        public ProductAvailabilitiesController(IProductAvailabilityService productAvailabilityService)
        {
            _productAvailabilityService = productAvailabilityService;
        }

        /// <summary>
        /// Получение информации о всех доступностях продуктов
        /// </summary>
        /// <returns>Список доступностей продуктов</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productAvailabilities = await _productAvailabilityService.GetAll();
            return Ok(productAvailabilities.Adapt<List<GetProductAvailabilityResponse>>());
        }

        /// <summary>
        /// Получение информации о доступности продукта по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация о доступности продукта</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productAvailability = await _productAvailabilityService.GetById(id);
            if (productAvailability == null) return NotFound();
            return Ok(productAvailability.Adapt<GetProductAvailabilityResponse>());
        }

        /// <summary>
        /// Создание новой доступности продукта
        /// </summary>
        /// <param name="request">Данные для создания доступности</param>
        /// <returns>Созданная доступность</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductAvailabilityRequest request)
        {
            var dto = request.Adapt<ProductAvailability>();
            await _productAvailabilityService.Create(dto);
            return Ok(dto.Adapt<GetProductAvailabilityResponse>());
        }

        /// <summary>
        /// Обновление информации о доступности продукта
        /// </summary>
        /// <param name="request">Обновляемые данные о доступности</param>
        /// <returns>Обновленная доступность</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetProductAvailabilityResponse request)
        {
            var dto = request.Adapt<ProductAvailability>();
            await _productAvailabilityService.Update(dto);
            return Ok(dto.Adapt<GetProductAvailabilityResponse>());
        }

        /// <summary>
        /// Удаление доступности продукта
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAvailabilityService.Delete(id);
            return NoContent();
        }
    }
}