using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class SuppliersService : ISuppliersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SuppliersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _repositoryWrapper.Supplier.FindAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _repositoryWrapper.Supplier
                .FindByCondition(x => x.SupplierId == id);
            return supplier.First();
        }

        public async Task Create(Supplier model)
        {
            await _repositoryWrapper.Supplier.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Supplier model)
        {
            _repositoryWrapper.Supplier.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var supplier = await _repositoryWrapper.Supplier
                .FindByCondition(x => x.SupplierId == id);

            _repositoryWrapper.Supplier.Delete(supplier.First());
            _repositoryWrapper.Save();
        }
    }
}