using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Artists;
using FumLabAPI.Contracts.Categories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistsService _artistService;

        public ArtistsController(IArtistsService artistService)
        {
            _artistService = artistService;
        }

        /// <summary>
        /// Получение списка всех художников
        /// </summary>
        /// <returns>Список художников</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistService.GetAll();
            return Ok(artists.Adapt<List<GetArtistsResponse>>());
        }

        /// <summary>
        /// Получение информации о конкретном художнике по ID
        /// </summary>
        /// <param name="id">ID художника</param>
        /// <returns>Информация о художнике</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artist = await _artistService.GetById(id);
            return Ok(artist.Adapt<GetArtistsResponse>());
        }

        /// <summary>
        /// Создание нового художника
        /// </summary>
        /// <param name="artist">Данные для создания художника</param>
        /// <returns>Созданный художник</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistsRequest artist)
        {
            var dto = artist.Adapt<Artist>();
            await _artistService.Create(dto);
            return Ok(dto.Adapt<GetArtistsResponse>());
        }

        /// <summary>
        /// Обновление информации о художнике
        /// </summary>
        /// <param name="artist">Обновляемые данные художника</param>
        /// <returns>Обновленный художник</returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetArtistsResponse artist)
        {
            var dto = artist.Adapt<Artist>();
            await _artistService.Update(dto);
            return Ok(dto.Adapt<GetArtistsResponse>());
        }

        /// <summary>
        /// Удаление художника
        /// </summary>
        /// <param name="id">ID художника</param>
        /// <returns>Успешное удаление</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.Delete(id);
            return Ok();
        }
    }
}
