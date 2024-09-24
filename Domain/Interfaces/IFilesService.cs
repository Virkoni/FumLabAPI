using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFilesService
    {
        Task<List<Domain.Models.File>> GetAll();
        Task<Domain.Models.File> GetById(int id);
        Task Create(Domain.Models.File model);
        Task Update(Domain.Models.File model);
        Task Delete(int id);
    }
}
