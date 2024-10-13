using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CartsService : ICartsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CartsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Cart>> GetAll()
        {
            return await _repositoryWrapper.Cart.FindAll();
        }

        public async Task<Cart> GetById(int id)
        {
            var cart = await _repositoryWrapper.Cart
                .FindByCondition(x => x.CartId == id);
            return cart.First();
        }

        public async Task Create(Cart model)
        {
            await _repositoryWrapper.Cart.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Cart model)
        {
            _repositoryWrapper.Cart.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var cart = await _repositoryWrapper.Cart
                .FindByCondition(x => x.CartId == id);

            _repositoryWrapper.Cart.Delete(cart.First());
            _repositoryWrapper.Save();
        }
    }
}
