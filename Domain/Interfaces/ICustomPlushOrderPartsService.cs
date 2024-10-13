using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomPlushOrderPartsService
    {
        Task<List<CustomPlushOrderPart>> GetAll();
        Task<CustomPlushOrderPart> GetById(int id);
        Task Create(CustomPlushOrderPart model);
        Task Update(CustomPlushOrderPart model);
        Task Delete(int id);
    }
}
