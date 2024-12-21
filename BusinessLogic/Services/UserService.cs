using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            // Exclude deleted users (IsDeleted = 1)
            return await _repositoryWrapper.User
                .FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id && x.IsDeleted == false);

            if (user is null || user.Count == 0)
            {
                throw new ArgumentNullException("User not found");
            }

            return user.First();
        }

        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // Ensure required fields are present
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException("Username is required");
            }

            if (string.IsNullOrEmpty(model.PasswordHash))
            {
                throw new ArgumentException("Password is required");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException("Email is required");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException("Username is required");
            }

            if (string.IsNullOrEmpty(model.PasswordHash))
            {
                throw new ArgumentException("Password is required");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException("Email is required");
            }

            // Check if the user exists and is not deleted
            var existingUser = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == model.UserId && x.IsDeleted == false);

            if (existingUser is null || existingUser.Count == 0)
            {
                throw new ArgumentNullException("User not found");
            }

            // Update the fields and timestamps
            model.UpdatedAt = DateTime.Now;
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id && x.IsDeleted == false);

            if (user is null || user.Count == 0)
            {
                throw new ArgumentNullException("User not found");
            }

            var userToDelete = user.First();
            userToDelete.IsDeleted = true;  // Soft delete
            userToDelete.UpdatedAt = DateTime.Now;

            _repositoryWrapper.User.Update(userToDelete);
            _repositoryWrapper.Save();
        }
    }
}