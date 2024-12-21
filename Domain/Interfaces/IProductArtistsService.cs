using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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