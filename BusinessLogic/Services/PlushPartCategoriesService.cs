using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PlushPartCategoriesService : IPlushPartCategoriesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PlushPartCategoriesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PlushPartCategory>> GetAll()
        {
            return await _repositoryWrapper.PlushPartCategory.FindAll();
        }

        public async Task<PlushPartCategory> GetById(int id)
        {
            var plushPartCategory = await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.PartCategoryId == id);
            return plushPartCategory.First();
        }

        public async Task Create(PlushPartCategory model)
        {
            await _repositoryWrapper.PlushPartCategory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PlushPartCategory model)
        {
            _repositoryWrapper.PlushPartCategory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var plushPartCategory = await _repositoryWrapper.PlushPartCategory
                .FindByCondition(x => x.PartCategoryId == id);

            _repositoryWrapper.PlushPartCategory.Delete(plushPartCategory.First());
            _repositoryWrapper.Save();
        }
    }
}
