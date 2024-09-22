using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PetshopContext _repoContext;

        private IUserRepository _user;
        private IRoleRepository _role;
        private IUserRoleRepository _userRole;

        public IUserRepository User
        {
            get 
            {
                if (_user == null)

                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)

                {
                    _role = new RoleRepository(_repoContext);
                }

                return _role;
            }
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)

                {
                    _userRole = new UserRoleRepository(_repoContext);
                }

                return _userRole;
            }
        }



        public RepositoryWrapper(PetshopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        { 
            await _repoContext.SaveChangesAsync();
        }
    }
}
