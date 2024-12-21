using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CustomPlushOrderPartsService : ICustomPlushOrderPartsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CustomPlushOrderPartsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomPlushOrderPart>> GetAll()
        {
            return await _repositoryWrapper.CustomPlushOrderPart.FindAll();
        }

        public async Task<CustomPlushOrderPart> GetById(int id)
        {
            var customPlushOrderPart = await _repositoryWrapper.CustomPlushOrderPart
                .FindByCondition(x => x.CustomOrderPartId == id);
            return customPlushOrderPart.First();
        }

        public async Task Create(CustomPlushOrderPart model)
        {
            await _repositoryWrapper.CustomPlushOrderPart.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CustomPlushOrderPart model)
        {
            _repositoryWrapper.CustomPlushOrderPart.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var customPlushOrderPart = await _repositoryWrapper.CustomPlushOrderPart
                .FindByCondition(x => x.CustomOrderPartId == id);

            _repositoryWrapper.CustomPlushOrderPart.Delete(customPlushOrderPart.First());
            _repositoryWrapper.Save();
        }
    }
}