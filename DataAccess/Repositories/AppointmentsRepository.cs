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
    public class AppointmentsRepository : RepositoryBase<Appointment>, IAppointmentsRepository
    {
        public AppointmentsRepository(PetshopContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
