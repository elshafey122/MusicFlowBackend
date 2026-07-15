using AutoMapper;
using FluentValidation;
using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Artist.Commands.Model;
using MusicFlow.Application.Features.Track.Commands.Model;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using track = MusicFlow.Domain.Entites.Track;

namespace MusicFlow.Application.Features.Track.Commands.Handler
{
    public class TrackCommandHandler : ResponseHandler, IRequestHandler<CreateTrackCommand, Response<TrackDto>>,
                                                        IRequestHandler<CreateDspsTrackCommand, Response<string>>,
                                                        IRequestHandler<PatchTrackCommand, Response<TrackDto>>
    {
        private readonly ITrackService _trackService;
        private readonly IValidator<CreateTrackCommand> _addtrackvalidator;
        private readonly IValidator<CreateDspsTrackCommand> _createDspsTrackValidatior;
        private readonly IValidator<PatchTrackCommand> _patchTrackValidator;
        private readonly IMapper _mapper;
        public TrackCommandHandler(ITrackService trackService, IValidator<CreateTrackCommand> addtrackvalidator, IMapper mapper, IValidator<CreateDspsTrackCommand> createDspsTrackValidatior, IValidator<PatchTrackCommand> patchTrackValidator)
        {
            _addtrackvalidator = addtrackvalidator;
            _mapper = mapper;
            _trackService = trackService;
            _createDspsTrackValidatior = createDspsTrackValidatior;
            _patchTrackValidator = patchTrackValidator;
        }

        public async Task<Response<TrackDto>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            var validator = _addtrackvalidator.Validate(request);
            if (!validator.IsValid)
            {
                var errors = string.Join(",", validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<TrackDto>(errors);
            }

            var track = _mapper.Map<Domain.Entites.Track>(request);
            var result = await _trackService.AddTrackAsync(track);
            switch (result)
            {
                case "trackExist":
                    return BadRequest<TrackDto>("Track is already exists");
                    break;
                case "artistNotExist":
                    return BadRequest<TrackDto>("Artist not found");
                    break;
                case "Failed":
                    return BadRequest<TrackDto>("Failed to add track");
                    break;
                default:
                    var trackDto = _mapper.Map<TrackDto>(track);
                    return Created<TrackDto>(trackDto, "added successfully");
                    break;
            }
        }

        public async Task<Response<string>> Handle(CreateDspsTrackCommand request, CancellationToken cancellationToken)
        {
            var validator = _createDspsTrackValidatior.Validate(request);
            if (!validator.IsValid)
            {
                var errors = string.Join(",", validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<string>(errors);
            }
            var result = await _trackService.AddDspsTrackAsync(request.TrackId,request.dspIds);
            switch (result)
            {
                case "trackNotExist":
                    return BadRequest<string>("Track is not exists");
                    break;
                case "Failed":
                    return BadRequest<string>("Failed to add dsp to track");
                    break;
                default:
                    return Created<string>("added successfully");
                    break;
            }
        }

        public async Task<Response<TrackDto>> Handle(PatchTrackCommand request, CancellationToken cancellationToken)
        {
            var validator = _patchTrackValidator.Validate(request);
            if (!validator.IsValid)
            {
                var errors = string.Join(",", validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<TrackDto>(errors);
            }
            var result = await _trackService.PatchTrackAsync(request.trackId, request.status);
            if (result == null)
            {
                return BadRequest<TrackDto>("Failed to update track");
            }
            var trackDto = _mapper.Map<TrackDto>(result);
            return Success<TrackDto>(trackDto, "updated successfully");
        }
    }
}
