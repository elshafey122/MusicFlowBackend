using AutoMapper;
using FluentValidation;
using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Artist.Commands.Model;
using MusicFlow.Application.Features.Artist.Queires.Model;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using artist = MusicFlow.Domain.Entites.Artist;

namespace MusicFlow.Application.Features.Artist.Commands.Handler
{
    public class AuthCommandHandler : ResponseHandler, IRequestHandler<CreateArtistCommand, Response<ArtistDto>>
    {
        private readonly IArtistService _artistService;
        private readonly IValidator<CreateArtistCommand> _addartistvalidator;
        private readonly IMapper _mapper;
        public AuthCommandHandler(IArtistService artistService, IValidator<CreateArtistCommand> addartistvalidator,IMapper mapper)
        {
            _artistService = artistService;
            _addartistvalidator = addartistvalidator;
            _mapper = mapper;
        }
        public async Task<Response<ArtistDto>> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var validator = _addartistvalidator.Validate(request);
            if (!validator.IsValid)
            {
                var errors = string.Join(",", validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<ArtistDto>(errors);
            }
            var artist = _mapper.Map<artist>(request);
            var result = await _artistService.AddArtistAsync(artist);
            if(result==null)
            {
                return BadRequest<ArtistDto>("Failed to add artist");
            }
            var artistdto = _mapper.Map<ArtistDto>(result);
            return Created<ArtistDto>(artistdto, "added successfully");
        }
    }
}
