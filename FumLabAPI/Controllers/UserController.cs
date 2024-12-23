using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.User;
using Mapster;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение информации о всех пользователях
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users.Adapt<List<GetUserResponse>>());
        }

        /// <summary>
        /// Получение информации о пользователе по id
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Информация о пользователе</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user.Adapt<GetUserResponse>());
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user">Данные для создания пользователя</param>
        /// <returns>Созданный пользователь</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            var dto = user.Adapt<User>();
            await _userService.Create(dto);
            return Ok(dto.Adapt<GetUserResponse>());
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <param name="user">Обновляемые данные пользователя</param>
        /// <returns>Обновленный пользователь</returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserResponse user)
        {
            var dto = user.Adapt<User>();
            await _userService.Update(dto);
            return Ok(dto.Adapt<GetUserResponse>());
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns>Успешное удаление</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}