using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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