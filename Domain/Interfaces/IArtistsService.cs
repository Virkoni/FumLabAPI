using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IArtistsService
    {
        Task<List<Artist>> GetAll();
        Task<Artist> GetById(int id);
        Task Create(Artist model);
        Task Update(Artist model);
        Task Delete(int id);
    }
}
