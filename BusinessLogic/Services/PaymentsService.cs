using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PaymentsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _repositoryWrapper.Payment.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<Payment> GetById(int id)
        {
            var payment = await _repositoryWrapper.Payment
                .FindByCondition(x => x.PaymentId == id && x.IsDeleted == false);

            if (payment is null || payment.Count == 0)
            {
                throw new ArgumentNullException("Payment not found");
            }

            return payment.First();
        }

        public async Task Create(Payment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.PaymentDate = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Payment.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Payment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingPayment = await _repositoryWrapper.Payment
                .FindByCondition(x => x.PaymentId == model.PaymentId && x.IsDeleted == false);

            if (existingPayment is null || existingPayment.Count == 0)
            {
                throw new ArgumentNullException("Payment not found");
            }

            model.PaymentDate = DateTime.Now;

            _repositoryWrapper.Payment.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var payment = await _repositoryWrapper.Payment
                .FindByCondition(x => x.PaymentId == id && x.IsDeleted == false);

            if (payment is null || payment.Count == 0)
            {
                throw new ArgumentNullException("Payment not found");
            }

            var paymentToDelete = payment.First();
            paymentToDelete.IsDeleted = true;

            _repositoryWrapper.Payment.Update(paymentToDelete);
            _repositoryWrapper.Save();
        }
    }
}