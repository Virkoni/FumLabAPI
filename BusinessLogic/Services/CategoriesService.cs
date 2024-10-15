using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoriesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _repositoryWrapper.Category
                .FindByCondition(x => x.CategoryId == id);

            if (category is null || category.Count == 0)
            {
                throw new ArgumentNullException("Category not found");
            }

            return category.First();
        }

        public async Task Create(Category model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(model.CategoryName))
            {
                throw new ArgumentException("CategoryName cannot be null or empty");
            }

            await _repositoryWrapper.Category.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Category model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingCategory = await _repositoryWrapper.Category
                .FindByCondition(x => x.CategoryId == model.CategoryId);

            if (existingCategory is null || existingCategory.Count == 0)
            {
                throw new ArgumentNullException("Category not found");
            }

            _repositoryWrapper.Category.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var category = await _repositoryWrapper.Category
                .FindByCondition(x => x.CategoryId == id);

            if (category is null || category.Count == 0)
            {
                throw new ArgumentNullException("Category not found");
            }

            _repositoryWrapper.Category.Delete(category.First());
            _repositoryWrapper.Save();
        }
    }
}
