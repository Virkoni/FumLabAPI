using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        /// <summary>
        /// Получение информации о всех поставщиках
        /// </summary>
        /// <returns></returns>

        // GET api/<SuppliersController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _suppliersService.GetAll());
        }

        /// <summary>
        /// Получение информации о поставщиках по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<SuppliersController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _suppliersService.GetById(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        /// <summary>
        /// Создание нового поставщика
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "supplierName": "string",
        ///       "contactInfo": "string",
        ///       "address": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="supplier">Поставщик</param>
        /// <returns></returns>

        // POST api/<SuppliersController>

        [HttpPost]
        public async Task<IActionResult> Add(Supplier supplier)
        {
            await _suppliersService.Create(supplier);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о поставщике
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "supplierId": 1,
        ///       "supplierName": "string",
        ///       "contactInfo": "string",
        ///       "address": "string",
        ///       "createdBy": 1,
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedBy": 1,
        ///       "isDeleted": 1,
        ///       
        ///     }
        ///
        /// </remarks>
        /// <param name="supplier">Поставщик</param>
        /// <returns></returns>

        // PUT api/<SuppliersController>

        [HttpPut]
        public async Task<IActionResult> Update(Supplier supplier)
        {
            await _suppliersService.Update(supplier);
            return Ok();
        }

        /// <summary>
        /// Удаление поставщика
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<SuppliersController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _suppliersService.Delete(id);
            return Ok();
        }
    }
}
