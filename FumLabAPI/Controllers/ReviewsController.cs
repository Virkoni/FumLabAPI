using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        /// <summary>
        /// Получение информации о всех отзывах
        /// </summary>
        /// <returns></returns>

        // GET api/<ReviewsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reviewsService.GetAll());
        }

        /// <summary>
        /// Получение информации об отзывах по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<ReviewsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewsService.GetById(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        /// <summary>
        /// Создание нового отзыва
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "productId": 1,  
        ///       "petId": 1,
        ///       "serviceId": 1,
        ///       "rating": 1,
        ///       "ratingText": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="review">Отзыв</param>
        /// <returns></returns>

        // POST api/<ReviewsController>

        [HttpPost]
        public async Task<IActionResult> Add(Review review)
        {
            await _reviewsService.Create(review);
            return Ok();
        }

        /// <summary>
        /// Изменение информации об отзыве
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "userId": 1,  
        ///       "productId": 1,  
        ///       "petId": 1,
        ///       "serviceId": 1,
        ///       "rating": 1,
        ///       "ratingText": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="review">Отзыв</param>
        /// <returns></returns>

        // PUT api/<ReviewsController>

        [HttpPut]
        public async Task<IActionResult> Update(Review review)
        {
            await _reviewsService.Update(review);
            return Ok();
        }

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<ReviewsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewsService.Delete(id);
            return Ok();
        }
    }
}
