using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CustomPlushOrdersService : ICustomPlushOrdersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CustomPlushOrdersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomPlushOrder>> GetAll()
        {
            return await _repositoryWrapper.CustomPlushOrder.FindAll();
        }

        public async Task<CustomPlushOrder> GetById(int id)
        {
            var customPlushOrder = await _repositoryWrapper.CustomPlushOrder
                .FindByCondition(x => x.CustomOrderId == id);
            return customPlushOrder.First();
        }

        public async Task Create(CustomPlushOrder model)
        {
            await _repositoryWrapper.CustomPlushOrder.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CustomPlushOrder model)
        {
            _repositoryWrapper.CustomPlushOrder.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var customPlushOrder = await _repositoryWrapper.CustomPlushOrder
                .FindByCondition(x => x.CustomOrderId == id);

            _repositoryWrapper.CustomPlushOrder.Delete(customPlushOrder.First());
            _repositoryWrapper.Save();
        }
    }
}
