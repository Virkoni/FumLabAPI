using Domain.Interfaces;
using Domain.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderItemsRepository : RepositoryBase<OrderItem>, IOrderItemsRepository
    {
        public OrderItemsRepository(PetshopContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
