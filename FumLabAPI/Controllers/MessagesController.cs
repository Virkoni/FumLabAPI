using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Contracts.Message;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FumLabAPI.Controllers
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
        /// <returns>Список сообщений</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messagesService.GetAll();
            return Ok(messages.Adapt<List<GetMessageResponse>>());
        }

        /// <summary>
        /// Получение информации о сообщении по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Информация о сообщении</returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messagesService.GetById(id);
            if (message == null) return NotFound();
            return Ok(message.Adapt<GetMessageResponse>());
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <param name="request">Данные для создания сообщения</param>
        /// <returns>Созданное сообщение</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateMessageRequest request)
        {
            var dto = request.Adapt<Message>();
            await _messagesService.Create(dto);
            return Ok(dto.Adapt<GetMessageResponse>());
        }

        /// <summary>
        /// Обновление информации о сообщении
        /// </summary>
        /// <param name="request">Обновляемые данные сообщения</param>
        /// <returns>Обновленное сообщение</returns>

        [HttpPut]
        public async Task<IActionResult> Update(GetMessageResponse request)
        {
            var dto = request.Adapt<Message>();
            await _messagesService.Update(dto);
            return Ok(dto.Adapt<GetMessageResponse>());
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Успешное удаление</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesService.Delete(id);
            return NoContent();
        }
    }
}
