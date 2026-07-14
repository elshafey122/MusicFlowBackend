using AutoMapper;
using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Artist.Queires.Model;
using MusicFlow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Artist.Commands.Handler
{
    public class ArtistQueryHandler : ResponseHandler, IRequestHandler<GetAllArtistsQuery, Response<List<ArtistDto>>>
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        public ArtistQueryHandler(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }
        public async Task<Response<List<ArtistDto>>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistService.GetAllArtistsAsync();
            if (artists == null)
            {
                return NotFound<List<ArtistDto>>("No data retrieved");
            }
            var artitstsDto = _mapper.Map<List<ArtistDto>>(artists);
            return Success<List<ArtistDto>>(artitstsDto, "Artists retrieved successfully");
        }
    }
}
