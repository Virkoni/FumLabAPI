using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public InventoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _repositoryWrapper.Inventory.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<Inventory> GetById(int id)
        {
            var inventory = await _repositoryWrapper.Inventory
                .FindByCondition(x => x.InventoryId == id && x.IsDeleted == false);

            if (inventory is null || inventory.Count == 0)
            {
                throw new ArgumentNullException("Inventory item not found");
            }

            return inventory.First();
        }

        public async Task Create(Inventory model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.LastUpdated = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Inventory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Inventory model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingInventory = await _repositoryWrapper.Inventory
                .FindByCondition(x => x.InventoryId == model.InventoryId && x.IsDeleted == false);

            if (existingInventory is null || existingInventory.Count == 0)
            {
                throw new ArgumentNullException("Inventory item not found");
            }

            model.LastUpdated = DateTime.Now; // Update the timestamp
            _repositoryWrapper.Inventory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var inventory = await _repositoryWrapper.Inventory
                .FindByCondition(x => x.InventoryId == id && x.IsDeleted == false);

            if (inventory is null || inventory.Count == 0)
            {
                throw new ArgumentNullException("Inventory item not found");
            }

            var inventoryToDelete = inventory.First();
            inventoryToDelete.IsDeleted = true;

            _repositoryWrapper.Inventory.Update(inventoryToDelete);
            _repositoryWrapper.Save();
        }
    }
}