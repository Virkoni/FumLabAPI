using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        Task Create(Appointment model);
        Task Update(Appointment model);
        Task Delete(int id);
    }
}
