using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FilesService : IFilesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public FilesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Domain.Models.File>> GetAll()
        {
            return await _repositoryWrapper.File.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<Domain.Models.File> GetById(int id)
        {
            var file = await _repositoryWrapper.File
                .FindByCondition(x => x.FileId == id && x.IsDeleted == false);

            if (file is null || file.Count == 0)
            {
                throw new ArgumentNullException("File not found");
            }

            return file.First();
        }

        public async Task Create(Domain.Models.File model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.IsDeleted = false;
            model.CreatedAt = DateTime.Now; 

            await _repositoryWrapper.File.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Domain.Models.File model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingFile = await _repositoryWrapper.File
                .FindByCondition(x => x.FileId == model.FileId && x.IsDeleted == false);

            if (existingFile is null || existingFile.Count == 0)
            {
                throw new ArgumentNullException("File not found");
            }

            _repositoryWrapper.File.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var file = await _repositoryWrapper.File
                .FindByCondition(x => x.FileId == id && x.IsDeleted == false);

            if (file is null || file.Count == 0)
            {
                throw new ArgumentNullException("File not found");
            }

            var fileToDelete = file.First();
            fileToDelete.IsDeleted = true; 

            _repositoryWrapper.File.Update(fileToDelete);
            _repositoryWrapper.Save();
        }
    }
}
