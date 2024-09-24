using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ServiceService : IServiceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ServiceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Service>> GetAll()
        {
            return await _repositoryWrapper.Service.FindAll();
        }

        public async Task<Service> GetById(int id)
        {
            var service = await _repositoryWrapper.Service
                .FindByCondition(x => x.ServiceId == id);
            return service.First();
        }

        public async Task Create(Service model)
        {
            await _repositoryWrapper.Service.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Service model)
        {
            _repositoryWrapper.Service.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var service = await _repositoryWrapper.Service
                .FindByCondition(x => x.ServiceId == id);

            _repositoryWrapper.Service.Delete(service.First());
            _repositoryWrapper.Save();
        }
    }
}