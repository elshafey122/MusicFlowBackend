using AutoMapper;
using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Artist.Queires.Model;
using MusicFlow.Application.Features.Track.Queires.Model;
using MusicFlow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Queires.Handler
{
    public class TrackQueryHandler : ResponseHandler, IRequestHandler<GetAllTracksQuery, Response<List<TrackDto>>>,
                                                      IRequestHandler<GetTrackQuery, Response<TrackDspsDto>>
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;
        public TrackQueryHandler(ITrackService trackService, IMapper mapper)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        public async Task<Response<List<TrackDto>>> Handle(GetAllTracksQuery request, CancellationToken cancellationToken)
        {
            var result = await _trackService.GetAllTracksAsync(request.ArtistId, request.Genre, request.Status);
            if(result.Count()==0)
            {
                return NotFound<List<TrackDto>>("No data retrieved");
            }
            var TracksDto = _mapper.Map<List<TrackDto>>(result);
            return Success<List<TrackDto>>(TracksDto, "Tracks retrieved successfully");
        }

        public async Task<Response<TrackDspsDto>> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            var track = await _trackService.GetTrackAsync(request.TrackId);
            if (track == null)
            {
                return NotFound<TrackDspsDto>("No data retrieved");
            }
            var TrackDspsDto = _mapper.Map<TrackDspsDto>(track);
            return Success<TrackDspsDto>(TrackDspsDto, "Tracks retrieved successfully");
        }
    }
}