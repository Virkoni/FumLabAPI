using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PetsService : IPetsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PetsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _repositoryWrapper.Pet.FindAll();
        }

        public async Task<Pet> GetById(int id)
        {
            var appointment = await _repositoryWrapper.Pet
                .FindByCondition(x => x.PetId == id);
            return appointment.First();
        }

        public async Task Create(Pet model)
        {
            await _repositoryWrapper.Pet.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Pet model)
        {
            _repositoryWrapper.Pet.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var pet = await _repositoryWrapper.Pet
                .FindByCondition(x => x.PetId == id);

            _repositoryWrapper.Pet.Delete(pet.First());
            _repositoryWrapper.Save();
        }
    }
}