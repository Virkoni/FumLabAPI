using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICartsService
    {
        Task<List<Cart>> GetAll();
        Task<Cart> GetById(int id);
        Task Create(Cart model);
        Task Update(Cart model);
        Task Delete(int id);
    }
}