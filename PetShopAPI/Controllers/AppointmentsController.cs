using BusinessLogic.Services;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;

        public AppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        /// <summary>
        /// Получение информации о всех встречах
        /// </summary>
        /// <returns></returns>

        // GET api/<AppointmentsController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _appointmentsService.GetAll());
        }

        /// <summary>
        /// Получение информации о встрече по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<AppointmentsController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _appointmentsService.GetById(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        /// <summary>
        /// Создание новой встречи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "userId": 1,
        ///        "serviceId": 1,
        ///        "appointmentDate": "2024-09-19T14:05:14.947Z",
        ///        "status": "string"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Встреча</param>
        /// <returns></returns>

        // POST api/<AppointmentsController>


        [HttpPost]
        public async Task<IActionResult> Add(Appointment appointment)
        {
            await _appointmentsService.Create(appointment);
            return Ok();
        }

        /// <summary>
        /// Создание новой встречи
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "appointmentId": 1,
        ///        "userId": 1,
        ///        "serviceId": 1,
        ///        "appointmentDate": "2024-09-19T14:05:14.947Z",
        ///        "status": "string",
        ///        "createdAt": "2024-09-19T14:05:14.947Z",
        ///        "createdAt": "2024-09-19T14:05:14.947Z",
        ///        "isDeleted": 1,
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="breed">Встреча</param>
        /// <returns></returns>

        // POST api/<AppointmentsController>

        [HttpPut]
        public async Task<IActionResult> Update(Appointment appointment)
        {
            await _appointmentsService.Update(appointment);
            return Ok();
        }


        /// <summary>
        /// Удаление встречи
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<AppointmentsController>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentsService.Delete(id);
            return Ok();
        }
    }
}
