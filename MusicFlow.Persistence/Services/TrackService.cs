using Microsoft.EntityFrameworkCore;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Enum;
using MusicFlow.Persistence.IRepositories;
using MusicFlow.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IDspRepository _dspRepository;
        private readonly ITrackDistRepository _trackDistRepository;
        public TrackService(ITrackRepository trackRepository, IDspRepository dspRepository, ITrackDistRepository trackDistRepository)
        {
            _trackRepository = trackRepository;
            _dspRepository = dspRepository;
            _trackDistRepository = trackDistRepository;
        }

        public async Task<string> AddDspsTrackAsync(string trackId, List<string> DspIds)
        {
            var trackExists = _trackRepository.GetTableNoTracking().Any(a => a.Id == Guid.Parse(trackId));
            if (!trackExists)
            {
                return "trackNotExist";
            }
            foreach (var dsp in DspIds)
            {
                var CheckDspTrack = CheckTrackDpsExist(trackId,dsp);
                if (CheckDspTrack)
                {
                    var track = new TrackDistribution
                    {
                        Id = Guid.NewGuid(),
                        TrackId = Guid.Parse(trackId),
                        DspId = Guid.Parse(dsp),
                        SubmittedAt = DateTime.UtcNow,
                        Status = DistributionStatus.Pending
                    };
                    await _trackDistRepository.AddAsync(track);
                }
            }
            var complete = await _trackRepository.SaveChanges();
            if (complete == 0)
            {
                return "Failed";
            }
            return "Success";
        }

        private bool CheckTrackDpsExist(string trackId,string dsp)
        {
            var dspExists = _dspRepository.GetTableNoTracking().Any(a => a.Id== Guid.Parse(dsp));
            var trackDspExists = _trackDistRepository.GetTableNoTracking().Any(a => a.TrackId == Guid.Parse(trackId) && a.DspId == Guid.Parse(dsp));
            if (dspExists && !trackDspExists)
            {
                return true;
            }
            return false;
        }

        public async Task<string> AddTrackAsync(Track track)
        {
            var trackExists = _trackRepository.GetTableNoTracking().Any(a => a.ISRC == track.ISRC);
            if (trackExists)
            {
                return "trackExist";
            }
            var artistExists = _trackRepository.GetTableNoTracking().Any(a => a.ArtistId == track.ArtistId);
            if (!artistExists)
            {
                return "artistNotExist";
            }
            await _trackRepository.AddAsync(track);
            var complete = await _trackRepository.SaveChanges();
            if (complete == 0)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<List<Track>> GetAllTracksAsync(string? artistId, string? genre, string? status)
        {
            var tracks =  _trackRepository.GetTableNoTracking();
            if (artistId != null)
            {
                tracks = tracks.Where(t => t.ArtistId == Guid.Parse(artistId));
            }
            if (genre != null)
            {
                tracks = tracks.Where(t => t.Genre == genre);
            }
            if (status != null)
            {
                if (Enum.TryParse<TrackStatus>(status, true, out var statusout))
                {
                    tracks = tracks.Where(t => t.Status ==  statusout);
                }
            }
            return await tracks.ToListAsync();
        }

        public async Task<Track> GetTrackAsync(string trackId)
        {
            var track = await _trackRepository.GetTableNoTracking().Include(x=>x.TrackDistributions).ThenInclude(x=>x.Dsp).FirstOrDefaultAsync(a => a.Id == Guid.Parse(trackId));
            return track;
        }

        public async Task<Track> PatchTrackAsync(string trackId, string status)
        {
            var track = _trackRepository.GetTableNoTracking().FirstOrDefault(a => a.Id == Guid.Parse(trackId));
            if (track == null)
            {
                return null;
            }
            if (Enum.TryParse<TrackStatus>(status, true, out var statusout))
            {
                track.Status = statusout;
                await _trackRepository.UpdateAsync(track);
                var complete = await _trackRepository.SaveChanges();
                if (complete == 0)
                {
                    return null;
                }
                return track;
            }
            return null;
        }
    }
}
