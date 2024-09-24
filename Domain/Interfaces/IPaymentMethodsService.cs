using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPaymentMethodsService
    {
        Task<List<PaymentMethod>> GetAll();
        Task<PaymentMethod> GetById(int id);
        Task Create(PaymentMethod model);
        Task Update(PaymentMethod model);
        Task Delete(int id);
    }
}
