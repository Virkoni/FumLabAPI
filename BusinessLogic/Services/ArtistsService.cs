using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

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

            if (artist is null || artist.Count == 0)
            {
                throw new ArgumentNullException("Artist not found");
            }

            return artist.First();
        }

        public async Task Create(Artist model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(model.ArtistName))
            {
                throw new ArgumentException("ArtistName cannot be null or empty");
            }

            await _repositoryWrapper.Artist.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Artist model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingArtist = await _repositoryWrapper.Artist
                .FindByCondition(x => x.ArtistId == model.ArtistId);

            if (existingArtist is null || existingArtist.Count == 0)
            {
                throw new ArgumentNullException("Artist not found");
            }

            _repositoryWrapper.Artist.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var artist = await _repositoryWrapper.Artist
                .FindByCondition(x => x.ArtistId == id);

            if (artist is null || artist.Count == 0)
            {
                throw new ArgumentNullException("Artist not found");
            }

            _repositoryWrapper.Artist.Delete(artist.First());
            _repositoryWrapper.Save();
        }
    }
}