using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductAvailabilityService
    {
        Task<List<ProductAvailability>> GetAll();
        Task<ProductAvailability> GetById(int id);
        Task Create(ProductAvailability model);
        Task Update(ProductAvailability model);
        Task Delete(int id);
    }
}