using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PlushPartsService : IPlushPartsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PlushPartsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PlushPart>> GetAll()
        {
            return await _repositoryWrapper.PlushPart.FindAll();
        }

        public async Task<PlushPart> GetById(int id)
        {
            var plushPart = await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.PartId == id);
            return plushPart.First();
        }

        public async Task Create(PlushPart model)
        {
            await _repositoryWrapper.PlushPart.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PlushPart model)
        {
            _repositoryWrapper.PlushPart.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var plushPart = await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.PartId == id);

            _repositoryWrapper.PlushPart.Delete(plushPart.First());
            _repositoryWrapper.Save();
        }
    }
}
