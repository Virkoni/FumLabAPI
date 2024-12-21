using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserRoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserRole>> GetAll()
        {
            return await _repositoryWrapper.UserRole.FindAll();
        }

        public async Task<UserRole> GetById(int id)
        {
            var userRole = await _repositoryWrapper.UserRole
                .FindByCondition(x => x.UserRoleId == id);

            if (userRole is null || userRole.Count == 0)
            {
                throw new ArgumentNullException("UserRole not found");
            }

            return userRole.First();
        }

        public async Task Create(UserRole model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Ensure foreign keys (UserId and RoleId) are present
            if (model.UserId <= 0)
            {
                throw new ArgumentException("Invalid UserId");
            }

            if (model.RoleId <= 0)
            {
                throw new ArgumentException("Invalid RoleId");
            }

            model.AssignedAt = DateTime.Now;

            await _repositoryWrapper.UserRole.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UserRole model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingUserRole = await _repositoryWrapper.UserRole
                .FindByCondition(x => x.UserRoleId == model.UserRoleId);

            if (existingUserRole is null || existingUserRole.Count == 0)
            {
                throw new ArgumentNullException("UserRole not found");
            }

            _repositoryWrapper.UserRole.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userRole = await _repositoryWrapper.UserRole
                .FindByCondition(x => x.UserRoleId == id);

            if (userRole is null || userRole.Count == 0)
            {
                throw new ArgumentNullException("UserRole not found");
            }

            _repositoryWrapper.UserRole.Delete(userRole.First());
            _repositoryWrapper.Save();
        }
    }
}