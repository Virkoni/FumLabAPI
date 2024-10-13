using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

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
