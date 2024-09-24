using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPetsService
    {
        Task<List<Pet>> GetAll();
        Task<Pet> GetById(int id);
        Task Create(Pet model);
        Task Update(Pet model);
        Task Delete(int id);
    }
}
