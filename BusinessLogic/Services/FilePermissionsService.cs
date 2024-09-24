using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class FilePermissionsService : IFilePermissionsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FilePermissionsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<FilePermission>> GetAll()
        {
            return await _repositoryWrapper.FilePermission.FindAll();
        }

        public async Task<FilePermission> GetById(int id)
        {
            var filePermission = await _repositoryWrapper.FilePermission
                .FindByCondition(x => x.PermissionId == id);
            return filePermission.First();
        }

        public async Task Create(FilePermission model)
        {
            await _repositoryWrapper.FilePermission.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(FilePermission model)
        {
            _repositoryWrapper.FilePermission.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var filePermission = await _repositoryWrapper.FilePermission
                .FindByCondition(x => x.PermissionId == id);

            _repositoryWrapper.FilePermission.Delete(filePermission.First());
            _repositoryWrapper.Save();
        }
    }
}