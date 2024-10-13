using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPlushPartsService
    {
        Task<List<PlushPart>> GetAll();
        Task<PlushPart> GetById(int id);
        Task Create(PlushPart model);
        Task Update(PlushPart model);
        Task Delete(int id);
    }
}
