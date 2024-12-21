using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrdersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repositoryWrapper.Order.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _repositoryWrapper.Order
                .FindByCondition(x => x.OrderId == id && x.IsDeleted == false);

            if (order is null || order.Count == 0)
            {
                throw new ArgumentNullException("Order not found");
            }

            return order.First();
        }

        public async Task Create(Order model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.OrderDate = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Order.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Order model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingOrder = await _repositoryWrapper.Order
                .FindByCondition(x => x.OrderId == model.OrderId && x.IsDeleted == false);

            if (existingOrder is null || existingOrder.Count == 0)
            {
                throw new ArgumentNullException("Order not found");
            }

            model.OrderDate = DateTime.Now;

            _repositoryWrapper.Order.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var order = await _repositoryWrapper.Order
                .FindByCondition(x => x.OrderId == id && x.IsDeleted == false);

            if (order is null || order.Count == 0)
            {
                throw new ArgumentNullException("Order not found");
            }

            var orderToDelete = order.First();
            orderToDelete.IsDeleted = true;

            _repositoryWrapper.Order.Update(orderToDelete);
            _repositoryWrapper.Save();
        }
    }
}