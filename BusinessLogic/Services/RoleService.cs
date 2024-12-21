using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

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

            if (role is null || role.Count == 0)
            {
                throw new ArgumentNullException("Role not found");
            }

            return role.First();
        }

        public async Task Create(Role model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Ensure required fields are present
            if (string.IsNullOrEmpty(model.RoleName))
            {
                throw new ArgumentException("RoleName is required");
            }

            model.CreatedAt = DateTime.Now;

            await _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Role model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingRole = await _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == model.RoleId);

            if (existingRole is null || existingRole.Count == 0)
            {
                throw new ArgumentNullException("Role not found");
            }

            _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.RoleId == id);

            if (role is null || role.Count == 0)
            {
                throw new ArgumentNullException("Role not found");
            }

            _repositoryWrapper.Role.Delete(role.First());
            _repositoryWrapper.Save();
        }
    }
}