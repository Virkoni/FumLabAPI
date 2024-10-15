using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class PlushPartCategoriesService : IPlushPartCategoriesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PlushPartCategoriesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PlushPartCategory>> GetAll()
        {
            return await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<PlushPartCategory> GetById(int id)
        {
            var plushPartCategory = await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.PartCategoryId == id && x.IsDeleted == false);

            if (plushPartCategory is null || plushPartCategory.Count == 0)
            {
                throw new ArgumentNullException("PlushPartCategory not found");
            }

            return plushPartCategory.First();
        }

        public async Task Create(PlushPartCategory model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(model.PartCategoryName))
            {
                throw new ArgumentException("PartCategoryName is required");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false; 

            await _repositoryWrapper.PlushPartCategory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PlushPartCategory model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingCategory = await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.PartCategoryId == model.PartCategoryId && x.IsDeleted == false);

            if (existingCategory is null || existingCategory.Count == 0)
            {
                throw new ArgumentNullException("PlushPartCategory not found");
            }


            if (string.IsNullOrWhiteSpace(model.PartCategoryName))
            {
                throw new ArgumentException("PartCategoryName is required");
            }

            model.UpdatedAt = DateTime.Now; 

            _repositoryWrapper.PlushPartCategory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var plushPartCategory = await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.PartCategoryId == id && x.IsDeleted == false);

            if (plushPartCategory is null || plushPartCategory.Count == 0)
            {
                throw new ArgumentNullException("PlushPartCategory not found");
            }

            var categoryToDelete = plushPartCategory.First();
            categoryToDelete.IsDeleted = true; 
            categoryToDelete.UpdatedAt = DateTime.Now;

            _repositoryWrapper.PlushPartCategory.Update(categoryToDelete);
            _repositoryWrapper.Save();
        }
    }
}
