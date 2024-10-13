using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        /// <summary>
        /// Получение информации о всех питомцах
        /// </summary>
        /// <returns></returns>

        // GET api/<PetsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _petsService.GetAll());
        }

        /// <summary>
        /// Получение информации о питомцах по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<PetsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petsService.GetById(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        /// <summary>
        /// Создание нового питомца
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///     
        /// 
        ///     }
        ///
        /// </remarks>
        /// <param name="pet">питомец</param>
        /// <returns></returns>

        // POST api/<PetsController>

        [HttpPost]
        public async Task<IActionResult> Add(Pet pet)
        {
            await _petsService.Create(pet);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о питомцах
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "userId": 1,
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="user">питомец</param>
        /// <returns></returns>

        // PUT api/<PetsController>

        [HttpPut]
        public async Task<IActionResult> Update(Pet pet)
        {
            await _petsService.Update(pet);
            return Ok();
        }

        /// <summary>
        /// Удаление питомца
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<PetsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _petsService.Delete(id);
            return Ok();
        }
    }
}
