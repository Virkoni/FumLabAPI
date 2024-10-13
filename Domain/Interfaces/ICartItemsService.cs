using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICartItemsService
    {
        Task<List<CartItem>> GetAll();
        Task<CartItem> GetById(int id);
        Task Create(CartItem model);
        Task Update(CartItem model);
        Task Delete(int id);
    }
}
