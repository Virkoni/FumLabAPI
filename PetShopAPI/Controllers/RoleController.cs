using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
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
        /// <returns></returns>

        // GET api/<UserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }

        /// <summary>
        /// Получение информации о роли по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<RoleController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetById(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "roleName": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>

        // POST api/<RoleController>

        [HttpPost]
        public async Task<IActionResult> Add(Role role)
        {
            await _roleService.Create(role);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "roleId": 1,
        ///       "roleName": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>

        // PUT api/<RoleController>

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            await _roleService.Update(role);
            return Ok();
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<UserController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}
