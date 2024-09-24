using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class InventoryService : IInventoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public InventoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _repositoryWrapper.Inventory.FindAll();
        }

        public async Task<Inventory> GetById(int id)
        {
            var inventory = await _repositoryWrapper.Inventory
                .FindByCondition(x => x.InventoryId == id);
            return inventory.First();
        }

        public async Task Create(Inventory model)
        {
            await _repositoryWrapper.Inventory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Inventory model)
        {
            _repositoryWrapper.Inventory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var inventory = await _repositoryWrapper.Inventory
                .FindByCondition(x => x.InventoryId == id);

            _repositoryWrapper.Inventory.Delete(inventory.First());
            _repositoryWrapper.Save();
        }
    }
}