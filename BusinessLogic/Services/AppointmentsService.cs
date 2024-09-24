
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class AppointmentsService : IAppointmentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AppointmentsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _repositoryWrapper.Appointment.FindAll();
        }

        public async Task<Appointment> GetById(int id)
        {
            var appointment = await _repositoryWrapper.Appointment
                .FindByCondition(x => x.AppointmentId == id);
            return appointment.First();
        }

        public async Task Create(Appointment model)
        {
            await _repositoryWrapper.Appointment.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Appointment model)
        {
            _repositoryWrapper.Appointment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var appointment = await _repositoryWrapper.Appointment
                .FindByCondition(x => x.AppointmentId == id);

            _repositoryWrapper.Appointment.Delete(appointment.First());
            _repositoryWrapper.Save();
        }
    }
}