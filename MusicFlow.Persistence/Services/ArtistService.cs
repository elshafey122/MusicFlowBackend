using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Artist> AddArtistAsync(Artist artist)
        {
            var artistExists = _artistRepository.GetTableNoTracking().Any(a => a.Email == artist.Email);
            if (artistExists)
            {
                return null;
            }
            await _artistRepository.AddAsync(artist);
            var complete = await _artistRepository.SaveChanges();
            if (complete == 0)
            {
                return null;
            }
            return artist;
        }

        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            var artists = await _artistRepository.GetTableNoTracking().Include(x=>x.Tracks).ToListAsync();
            return artists;
        }
    }
}
