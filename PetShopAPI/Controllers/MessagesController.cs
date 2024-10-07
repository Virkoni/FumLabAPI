using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        /// <summary>
        /// Получение информации о всех пользователях
        /// </summary>
        /// <returns></returns>

        // GET api/<UserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messagesService.GetAll());
        }

        /// <summary>
        /// Получение информации о пользователе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UserController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messagesService.GetById(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "username": "string",
        ///        "email" : "email@gmail.com",
        ///        "passwordHash" : "!Pa$$word123@"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // POST api/<UserController>

        [HttpPost]
        public async Task<IActionResult> Add(Message message)
        {
            await _messagesService.Create(message);
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
        ///       "userId": 1,
        ///       "email": "string",
        ///       "passwordHash": "string",
        ///       "username": "string",
        ///       "createdAt": "2024-09-19T14:05:14.947Z",
        ///       "updatedAt": "2024-09-19T14:05:14.947Z",
        ///       "isDeleted": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Сообшение</param>
        /// <returns></returns>

        // PUT api/<UserController>

        [HttpPut]
        public async Task<IActionResult> Update(Message message)
        {
            await _messagesService.Update(message);
            return Ok();
        }

        /// <summary>
        /// Удаление сообщений
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<UserController>


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesService.Delete(id);
            return Ok();
        }
    }
}
