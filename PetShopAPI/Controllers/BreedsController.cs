using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedsController : ControllerBase
    {
        private readonly IBreedsService _breedsService;

        public BreedsController(IBreedsService breedsService)
        {
            _breedsService = breedsService;
        }

        /// <summary>
        /// Получение информации о всех породах
        /// </summary>
        /// <returns></returns>

        // GET api/<BreedsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _breedsService.GetAll());
        }

        /// <summary>
        /// Получение информации о породе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<BreedsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var breed = await _breedsService.GetById(id);
            if (breed == null) return NotFound();
            return Ok(breed);
        }

        /// <summary>
        /// Создание новой породы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "breedName": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Порода</param>
        /// <returns></returns>

        // POST api/<BreedsController>

        [HttpPost]
        public async Task<IActionResult> Add(Breed breed)
        {
            await _breedsService.Create(breed);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "breedId": 1,
        ///       "breedName": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Порода</param>
        /// <returns></returns>

        // PUT api/<BreedsController>

        [HttpPut]
        public async Task<IActionResult> Update(Breed breed)
        {
            await _breedsService.Update(breed);
            return Ok();
        }

        /// <summary>
        /// Удаление породы
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<BreedsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _breedsService.Delete(id);
            return Ok();
        }
    }
}
