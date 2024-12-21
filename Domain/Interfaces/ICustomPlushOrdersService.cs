using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomPlushOrdersService
    {
        Task<List<CustomPlushOrder>> GetAll();
        Task<CustomPlushOrder> GetById(int id);
        Task Create(CustomPlushOrder model);
        Task Update(CustomPlushOrder model);
        Task Delete(int id);
    }
}