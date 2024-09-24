using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class DiscountUsageService : IDiscountUsageService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DiscountUsageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<DiscountUsage>> GetAll()
        {
            return await _repositoryWrapper.DiscountUsage.FindAll();
        }

        public async Task<DiscountUsage> GetById(int id)
        {
            var discountUsage = await _repositoryWrapper.DiscountUsage
                .FindByCondition(x => x.DiscountUsageId == id);
            return discountUsage.First();
        }

        public async Task Create(DiscountUsage model)
        {
            await _repositoryWrapper.DiscountUsage.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(DiscountUsage model)
        {
            _repositoryWrapper.DiscountUsage.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var discountUsage = await _repositoryWrapper.DiscountUsage
                .FindByCondition(x => x.DiscountUsageId == id);

            _repositoryWrapper.DiscountUsage.Delete(discountUsage.First());
            _repositoryWrapper.Save();
        }
    }
}