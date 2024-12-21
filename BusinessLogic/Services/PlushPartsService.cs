using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class PlushPartsService : IPlushPartsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PlushPartsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PlushPart>> GetAll()
        {
            return await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<PlushPart> GetById(int id)
        {
            var plushPart = await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.PartId == id && x.IsDeleted == false);

            if (plushPart is null || plushPart.Count == 0)
            {
                throw new ArgumentNullException("PlushPart not found");
            }

            return plushPart.First();
        }

        public async Task Create(PlushPart model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Additional validation if needed
            if (string.IsNullOrWhiteSpace(model.PartName))
            {
                throw new ArgumentException("PartName is required");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.PlushPart.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PlushPart model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingPlushPart = await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.PartId == model.PartId && x.IsDeleted == false);

            if (existingPlushPart is null || existingPlushPart.Count == 0)
            {
                throw new ArgumentNullException("PlushPart not found");
            }

            if (string.IsNullOrWhiteSpace(model.PartName))
            {
                throw new ArgumentException("PartName is required");
            }

            _repositoryWrapper.PlushPart.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var plushPart = await _repositoryWrapper.PlushPart
                .FindByCondition(x => x.PartId == id && x.IsDeleted == false);

            if (plushPart is null || plushPart.Count == 0)
            {
                throw new ArgumentNullException("PlushPart not found");
            }

            var plushPartToDelete = plushPart.First();
            plushPartToDelete.IsDeleted = true; // Soft delete
            plushPartToDelete.UpdatedAt = DateTime.Now;

            _repositoryWrapper.PlushPart.Update(plushPartToDelete);
            _repositoryWrapper.Save();
        }
    }
}