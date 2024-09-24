
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrderItemsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _repositoryWrapper.OrderItem.FindAll();
        }

        public async Task<OrderItem> GetById(int id)
        {
            var orderItem = await _repositoryWrapper.OrderItem
                .FindByCondition(x => x.OrderItemId == id);
            return orderItem.First();
        }

        public async Task Create(OrderItem model)
        {
            await _repositoryWrapper.OrderItem.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(OrderItem model)
        {
            _repositoryWrapper.OrderItem.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var orderItem = await _repositoryWrapper.OrderItem
                .FindByCondition(x => x.OrderItemId == id);

            _repositoryWrapper.OrderItem.Delete(orderItem.First());
            _repositoryWrapper.Save();
        }
    }
}