using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlushPartCategoriesService
    {
        Task<List<PlushPartCategory>> GetAll();
        Task<PlushPartCategory> GetById(int id);
        Task Create(PlushPartCategory model);
        Task Update(PlushPartCategory model);
        Task Delete(int id);
    }
}