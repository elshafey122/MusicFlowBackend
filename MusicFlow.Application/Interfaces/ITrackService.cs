using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Interfaces
{
    public interface ITrackService
    {
        public Task<List<Track>> GetAllTracksAsync(string? artistId, string? genre, string? status);
        public Task<string> AddTrackAsync(Track track);
        public Task<string> AddDspsTrackAsync(string trackId , List<string> DspIds);
        public Task<Track> GetTrackAsync(string trackId);
        public Task <Track> PatchTrackAsync(string trackId, string status);
    }
}
