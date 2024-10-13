using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        /// Получение информации о всех ролях 
        /// </summary>
        /// <returns></returns>

        // GET api/<UserRoleController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRoleService.GetAll());
        }

        /// <summary>
        /// Получение информации о ролях по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UserRoleController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userRole = await _userRoleService.GetById(id);
            if (userRole == null) return NotFound();
            return Ok(userRole);
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "userId": 1,
        ///       "roleId": 1,
        ///       ??? my db fucking sucks
        ///     }
        ///
        /// </remarks>
        /// <param name="userRole">Пользователь</param>
        /// <returns></returns>

        // POST api/<UserRoleController>


        [HttpPost]
        public async Task<IActionResult> Add(UserRole userRole)
        {
            await _userRoleService.Create(userRole);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о ролях
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///     "userRoleId": 1,
        ///     "userId": 1,
        ///     "roleId": 1,
        ///     "assignedAt": "2024-09-19T14:05:14.947Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="userRole">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UserRoleController>


        [HttpPut]
        public async Task<IActionResult> Update(UserRole userRole)
        {
            await _userRoleService.Update(userRole);
            return Ok();
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<UserRoleController>


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleService.Delete(id);
            return Ok();
        }
    }
}
