using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductArtistsService
    {
        Task<List<ProductArtist>> GetAll();
        Task<ProductArtist> GetById(int id);
        Task Create(ProductArtist model);
        Task Update(ProductArtist model);
        Task Delete(int id);
    }
}
