using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ArtistsService : IArtistsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ArtistsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Artist>> GetAll()
        {
            return await _repositoryWrapper.Artist.FindAll();
        }

        public async Task<Artist> GetById(int id)
        {
            var artist = await _repositoryWrapper.Artist
                .FindByCondition(x => x.ArtistId == id);
            return artist.First();
        }

        public async Task Create(Artist model)
        {
            await _repositoryWrapper.Artist.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Artist model)
        {
            _repositoryWrapper.Artist.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var artist = await _repositoryWrapper.Artist
                .FindByCondition(x => x.ArtistId == id);

            _repositoryWrapper.Artist.Delete(artist.First());
            _repositoryWrapper.Save();
        }
    }
}
