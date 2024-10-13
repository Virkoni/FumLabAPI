using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountUsageController : ControllerBase
    {
        private readonly IDiscountUsageService _discountUsageService;

        public DiscountUsageController(IDiscountUsageService discountUsageService)
        {
            _discountUsageService = discountUsageService;
        }

        /// <summary>
        /// Получение информации о всех использованиях скидок
        /// </summary>
        /// <returns></returns>

        // GET api/<DiscountUsageController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _discountUsageService.GetAll());
        }

        /// <summary>
        /// Получение информации о использовании скидки по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<DiscountUsageController>-

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discountUsage = await _discountUsageService.GetById(id);
            if (discountUsage == null) return NotFound();
            return Ok(discountUsage);
        }

        /// <summary>
        /// Создание нового использования скидки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "discountId": 1,
        ///        "userId" : 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="discountUsage">Использование скидки</param>
        /// <returns></returns>

        // POST api/<DiscountUsageController>

        [HttpPost]
        public async Task<IActionResult> Add(DiscountUsage discountUsage)
        {
            await _discountUsageService.Create(discountUsage);
            return Ok();
        }

        /// <summary>
        /// Изменение информации об использовании скидки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "discountUsageId": 1,
        ///        "discountId": 1,
        ///        "userId" : 1,
        ///        "usedAt": "2024-09-19T14:05:14.947Z",
        ///        "isDeleted": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="discountUsage">Использование скидки</param>
        /// <returns></returns>

        // PUT api/<DiscountUsageController>

        [HttpPut]
        public async Task<IActionResult> Update(DiscountUsage discountUsage)
        {
            await _discountUsageService.Update(discountUsage);
            return Ok();
        }

        /// <summary>
        /// Удаление использования скидки
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<DiscountUsageController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountUsageService.Delete(id);
            return Ok();
        }
    }
}
