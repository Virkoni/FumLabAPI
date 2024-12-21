using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CartItemsService : ICartItemsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CartItemsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CartItem>> GetAll()
        {
            return await _repositoryWrapper.CartItem.FindAll();
        }

        public async Task<CartItem> GetById(int id)
        {
            var cartItem = await _repositoryWrapper.CartItem
                .FindByCondition(x => x.CartItemId == id);
            return cartItem.First();
        }

        public async Task Create(CartItem model)
        {
            await _repositoryWrapper.CartItem.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CartItem model)
        {
            _repositoryWrapper.CartItem.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var cartItem = await _repositoryWrapper.CartItem
                .FindByCondition(x => x.CartItemId == id);

            _repositoryWrapper.CartItem.Delete(cartItem.First());
            _repositoryWrapper.Save();
        }
    }
}