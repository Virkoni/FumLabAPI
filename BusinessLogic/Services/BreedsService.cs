using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class BreedsService : IBreedsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BreedsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Breed>> GetAll()
        {
            return await _repositoryWrapper.Breed.FindAll();
        }

        public async Task<Breed> GetById(int id)
        {
            var breed = await _repositoryWrapper.Breed
                .FindByCondition(x => x.BreedId == id);
            return breed.First();
        }

        public async Task Create(Breed model)
        {
            await _repositoryWrapper.Breed.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Breed model)
        {
            _repositoryWrapper.Breed.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var breed = await _repositoryWrapper.Breed
                .FindByCondition(x => x.BreedId == id);

            _repositoryWrapper.Breed.Delete(breed.First());
            _repositoryWrapper.Save();
        }
    }
}