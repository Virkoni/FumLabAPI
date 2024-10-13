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
        /// Получение информации о всех сообщениях
        /// </summary>
        /// <returns></returns>

        // GET api/<MessageController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messagesService.GetAll());
        }

        /// <summary>
        /// Получение информации о сообщении по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<MessageController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messagesService.GetById(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "senderId": 1,
        ///        "receiverId": 1,
        ///        "messageText": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>

        // POST api/<MessageController>

        [HttpPost]
        public async Task<IActionResult> Add(Message message)
        {
            await _messagesService.Create(message);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о сообщении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///        "messageId": 1,
        ///        "senderId": 1,
        ///        "receiverId": 1,
        ///        "messageText": "string",
        ///        "sentAt": "2024-09-19T14:05:14.947Z",
        ///        "isDeleted": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="message">Сообщение</param>
        /// <returns></returns>

        // PUT api/<MessageController>

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

        // DELETE api/<MessageController>


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesService.Delete(id);
            return Ok();
        }
    }
}
