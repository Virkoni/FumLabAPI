using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CustomPlushOrdersService : ICustomPlushOrdersService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CustomPlushOrdersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomPlushOrder>> GetAll()
        {
            return await _repositoryWrapper.CustomPlushOrder.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<CustomPlushOrder> GetById(int id)
        {
            var customPlushOrder = await _repositoryWrapper.CustomPlushOrder
                .FindByCondition(x => x.CustomOrderId == id && x.IsDeleted == false);

            if (customPlushOrder is null || customPlushOrder.Count == 0)
            {
                throw new ArgumentNullException("Custom plush order not found");
            }

            return customPlushOrder.First();
        }

        public async Task Create(CustomPlushOrder model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.IsDeleted = false;
            model.OrderDate = DateTime.Now;

            await _repositoryWrapper.CustomPlushOrder.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CustomPlushOrder model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingOrder = await _repositoryWrapper.CustomPlushOrder
                .FindByCondition(x => x.CustomOrderId == model.CustomOrderId && x.IsDeleted == false);

            if (existingOrder is null || existingOrder.Count == 0)
            {
                throw new ArgumentNullException("Custom plush order not found");
            }

            _repositoryWrapper.CustomPlushOrder.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var customPlushOrder = await _repositoryWrapper.CustomPlushOrder
                .FindByCondition(x => x.CustomOrderId == id && x.IsDeleted == false);

            if (customPlushOrder is null || customPlushOrder.Count == 0)
            {
                throw new ArgumentNullException("Custom plush order not found");
            }

            var orderToDelete = customPlushOrder.First();
            orderToDelete.IsDeleted = true;

            _repositoryWrapper.CustomPlushOrder.Update(orderToDelete);
            _repositoryWrapper.Save();
        }
    }
}