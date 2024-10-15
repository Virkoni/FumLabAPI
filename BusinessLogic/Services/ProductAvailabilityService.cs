using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class ProductAvailabilityService : IProductAvailabilityService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductAvailabilityService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ProductAvailability>> GetAll()
        {
            return await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<ProductAvailability> GetById(int id)
        {
            var productAvailability = await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.AvailabilityId == id && x.IsDeleted == false);

            if (productAvailability is null || productAvailability.Count == 0)
            {
                throw new ArgumentNullException("ProductAvailability not found");
            }

            return productAvailability.First();
        }

        public async Task Create(ProductAvailability model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.StartDate >= model.EndDate)
            {
                throw new ArgumentException("StartDate must be earlier than EndDate");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.ProductAvailability.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ProductAvailability model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingAvailability = await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.AvailabilityId == model.AvailabilityId && x.IsDeleted == false);

            if (existingAvailability is null || existingAvailability.Count == 0)
            {
                throw new ArgumentNullException("ProductAvailability not found");
            }

            if (model.StartDate >= model.EndDate)
            {
                throw new ArgumentException("StartDate must be earlier than EndDate");
            }

            _repositoryWrapper.ProductAvailability.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var productAvailability = await _repositoryWrapper.ProductAvailability
                .FindByCondition(x => x.AvailabilityId == id && x.IsDeleted == false);

            if (productAvailability is null || productAvailability.Count == 0)
            {
                throw new ArgumentNullException("ProductAvailability not found");
            }

            var availabilityToDelete = productAvailability.First();
            availabilityToDelete.IsDeleted = true; // Soft delete
            availabilityToDelete.CreatedAt = DateTime.Now;

            _repositoryWrapper.ProductAvailability.Update(availabilityToDelete);
            _repositoryWrapper.Save();
        }
    }
}
