using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Roles;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение информации о всех ролях
        /// </summary>
        /// <returns>Список ролей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles.Adapt<List<GetRoleResponse>>());
        }

        /// <summary>
        /// Получение информации о роли по id
        /// </summary>
        /// <param name="id">ID роли</param>
        /// <returns>Информация о роли</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetById(id);
            return Ok(role.Adapt<GetRoleResponse>());
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <param name="request">Данные для создания роли</param>
        /// <returns>Созданная роль</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleRequest request)
        {
            var dto = request.Adapt<Role>();
            await _roleService.Create(dto);
            return Ok(dto.Adapt<GetRoleResponse>());
        }

        /// <summary>
        /// Обновление информации о роли
        /// </summary>
        /// <param name="request">Обновляемые данные о роли</param>
        /// <returns>Обновленная роль</returns>
        [HttpPut]
        public async Task<IActionResult> Update(GetRoleResponse request)
        {
            var dto = request.Adapt<Role>();
            await _roleService.Update(dto);
            return Ok(dto.Adapt<GetRoleResponse>());
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">ID роли</param>
        /// <returns>Успешное удаление</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return NoContent();
        }
    }
}
