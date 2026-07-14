using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Interfaces
{
    public interface IArtistService
    {
        public Task<List<Artist>> GetAllArtistsAsync();
        public Task<Artist> AddArtistAsync(Artist artist);
    }
}
