using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.UserRole;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        /// <summary>
        /// Получение информации о всех ролях пользователей
        /// </summary>
        /// <returns>Список ролей пользователей</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _userRoleService.GetAll();
            return Ok(userRoles.Adapt<List<GetUserRoleResponse>>());
        }

        /// <summary>
        /// Получение информации о роли пользователя по id
        /// </summary>
        /// <param name="id">ID роли пользователя</param>
        /// <returns>Информация о роли пользователя</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userRole = await _userRoleService.GetById(id);
            if (userRole == null) return NotFound();
            return Ok(userRole.Adapt<GetUserRoleResponse>());
        }

        /// <summary>
        /// Назначение роли пользователю
        /// </summary>
        /// <param name="request">Данные для назначения роли</param>
        /// <returns>Успешное назначение</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRoleRequest request)
        {
            var dto = request.Adapt<UserRole>();
            await _userRoleService.Create(dto);
            return Ok(dto.Adapt<GetUserRoleResponse>());
        }

        /// <summary>
        /// Обновление информации о роли пользователя
        /// </summary>
        /// <param name="request">Обновляемые данные о роли пользователя</param>
        /// <returns>Успешное обновление</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetUserRoleResponse request)
        {
            var dto = request.Adapt<UserRole>();
            await _userRoleService.Update(dto);
            return Ok(dto.Adapt<GetUserRoleResponse>());
        }

        /// <summary>
        /// Удаление назначенной роли пользователя
        /// </summary>
        /// <param name="id">ID назначенной роли</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleService.Delete(id);
            return NoContent();
        }
    }
}