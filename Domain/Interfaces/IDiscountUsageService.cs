using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDiscountUsageService
    {
        Task<List<DiscountUsage>> GetAll();
        Task<DiscountUsage> GetById(int id);
        Task Create(DiscountUsage model);
        Task Update(DiscountUsage model);
        Task Delete(int id);
    }
}
