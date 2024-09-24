using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReviewsService
    {
        Task<List<Review>> GetAll();
        Task<Review> GetById(int id);
        Task Create(Review model);
        Task Update(Review model);
        Task Delete(int id);
    }
}
