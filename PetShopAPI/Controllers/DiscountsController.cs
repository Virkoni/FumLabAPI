using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsService _discountsService;

        public DiscountsController(IDiscountsService discountsService)
        {
            _discountsService = discountsService;
        }

        /// <summary>
        /// Получение информации о всех скидках
        /// </summary>
        /// <returns></returns>

        // GET api/<DiscountsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _discountsService.GetAll());
        }

        /// <summary>
        /// Получение информации о скидках по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<DiscountsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountsService.GetById(id);
            if (discount == null) return NotFound();
            return Ok(discount);
        }

        /// <summary>
        /// Создание новой скидки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "discountName": "string",
        ///        "discountPercentage" : decimal,
        ///        "usageLimit" : 3,
        ///        "StartDate": "2024-09-19T14:05:14.947Z",
        ///        "EndDate": "2024-09-19T14:05:14.947Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="discount">Скидка</param>
        /// <returns></returns>

        // POST api/<DiscountsController>

        [HttpPost]
        public async Task<IActionResult> Add(Discount discount)
        {
            await _discountsService.Create(discount);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о скидке
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "discountId": 1,
        ///        "discountName": "string",
        ///        "discountPercentage" : decimal,
        ///        "usageLimit" : 3,
        ///        "StartDate": "2024-09-19T14:05:14.947Z",
        ///        "EndDate": "2024-09-19T14:05:14.947Z",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="discount">Скидка</param>
        /// <returns></returns>

        // PUT api/<DiscountsController>

        [HttpPut]
        public async Task<IActionResult> Update(Discount discount)
        {
            await _discountsService.Update(discount);
            return Ok();
        }

        /// <summary>
        /// Удаление скидки
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<DiscountsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountsService.Delete(id);
            return Ok();
        }
    }
}
