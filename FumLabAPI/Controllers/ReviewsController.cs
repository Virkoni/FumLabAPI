using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Reviews;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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
        /// <returns>Список отзывов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewsService.GetAll();
            return Ok(reviews.Adapt<List<GetReviewResponse>>());
        }

        /// <summary>
        /// Получение информации об отзыве по id
        /// </summary>
        /// <param name="id">ID отзыва</param>
        /// <returns>Информация об отзыве</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewsService.GetById(id);
            return Ok(review.Adapt<GetReviewResponse>());
        }

        /// <summary>
        /// Создание нового отзыва
        /// </summary>
        /// <param name="request">Данные для создания отзыва</param>
        /// <returns>Созданный отзыв</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReviewRequest request)
        {
            var dto = request.Adapt<Review>();
            await _reviewsService.Create(dto);
            return Ok(dto.Adapt<GetReviewResponse>());
        }

        /// <summary>
        /// Обновление информации об отзыве
        /// </summary>
        /// <param name="request">Обновляемые данные о отзыве</param>
        /// <returns>Обновленный отзыв</returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetReviewResponse request)
        {
            var dto = request.Adapt<Review>();
            await _reviewsService.Update(dto);
            return Ok(dto.Adapt<GetReviewResponse>());
        }

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">ID отзыва</param>
        /// <returns>Успешное удаление</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewsService.Delete(id);
            return NoContent();
        }
    }
}