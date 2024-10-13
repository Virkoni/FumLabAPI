using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ProductAvailabilityService : IProductAvailabilityService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductAvailabilityService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ProductAvailability>> GetAll()
        {
            return await _repositoryWrapper.ProductAvailability.FindAll();
        }

        public async Task<ProductAvailability> GetById(int id)
        {
            var productAvailability = await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.AvailabilityId == id);
            return productAvailability.First();
        }

        public async Task Create(ProductAvailability model)
        {
            await _repositoryWrapper.ProductAvailability.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ProductAvailability model)
        {
            _repositoryWrapper.ProductAvailability.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var productAvailability = await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.AvailabilityId == id);

            _repositoryWrapper.ProductAvailability.Delete(productAvailability.First());
            _repositoryWrapper.Save();
        }
    }
}
