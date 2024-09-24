using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ProductSuppliersService : IProductSuppliersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductSuppliersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ProductsSupplier>> GetAll()
        {
            return await _repositoryWrapper.ProductSupplier.FindAll();
        }

        public async Task<ProductsSupplier> GetById(int id)
        {
            var productSupplier = await _repositoryWrapper.ProductSupplier
                .FindByCondition(x => x.ProductSupplierId == id);
            return productSupplier.First();
        }

        public async Task Create(ProductsSupplier model)
        {
            await _repositoryWrapper.ProductSupplier.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ProductsSupplier model)
        {
            _repositoryWrapper.ProductSupplier.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var productSupplier = await _repositoryWrapper.ProductSupplier
                .FindByCondition(x => x.ProductSupplierId == id);

            _repositoryWrapper.ProductSupplier.Delete(productSupplier.First());
            _repositoryWrapper.Save();
        }
    }
}