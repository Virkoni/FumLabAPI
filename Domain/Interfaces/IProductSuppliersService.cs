using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductSuppliersService
    {
        Task<List<ProductsSupplier>> GetAll();
        Task<ProductsSupplier> GetById(int id);
        Task Create(ProductsSupplier model);
        Task Update(ProductsSupplier model);
        Task Delete(int id);
    }
}
