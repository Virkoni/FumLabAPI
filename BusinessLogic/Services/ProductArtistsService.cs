using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ProductArtistsService : IProductArtistsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductArtistsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ProductArtist>> GetAll()
        {
            return await _repositoryWrapper.ProductArtist.FindAll();
        }

        public async Task<ProductArtist> GetById(int id)
        {
            var productArtist = await _repositoryWrapper.ProductArtist
                .FindByCondition(x => x.ProductArtistId == id);
            return productArtist.First();
        }

        public async Task Create(ProductArtist model)
        {
            await _repositoryWrapper.ProductArtist.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ProductArtist model)
        {
            _repositoryWrapper.ProductArtist.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var productArtist = await _repositoryWrapper.ProductArtist
                .FindByCondition(x => x.ProductArtistId == id);

            _repositoryWrapper.ProductArtist.Delete(productArtist.First());
            _repositoryWrapper.Save();
        }
    }
}
