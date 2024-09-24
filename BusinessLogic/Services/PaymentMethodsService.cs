using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentMethodsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PaymentMethod>> GetAll()
        {
            return await _repositoryWrapper.PaymentMethod.FindAll();
        }

        public async Task<PaymentMethod> GetById(int id)
        {
            var paymentMethod = await _repositoryWrapper.PaymentMethod
                .FindByCondition(x => x.PaymentMethodId == id);
            return paymentMethod.First();
        }

        public async Task Create(PaymentMethod model)
        {
            await _repositoryWrapper.PaymentMethod.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PaymentMethod model)
        {
            _repositoryWrapper.PaymentMethod.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var paymentMethod = await _repositoryWrapper.PaymentMethod
                .FindByCondition(x => x.PaymentMethodId == id);

            _repositoryWrapper.PaymentMethod.Delete(paymentMethod.First());
            _repositoryWrapper.Save();
        }
    }
}