using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _repositoryWrapper.Role.FindAll();
        }

        public async Task<Role> GetById(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == id);
            return role.First();
        }

        public async Task Create(Role model)
        {
            await _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Role model)
        {
            _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == id);

            _repositoryWrapper.Role.Delete(role.First());
            _repositoryWrapper.Save();
        }
    }
}