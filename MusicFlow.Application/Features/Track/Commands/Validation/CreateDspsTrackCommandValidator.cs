using FluentValidation;
using MusicFlow.Application.Features.Track.Commands.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Commands.Validation
{
    public class CreateDspsTrackCommandValidator : AbstractValidator<CreateDspsTrackCommand>
    {
        public CreateDspsTrackCommandValidator()
        {
            RuleFor(x => x.dspIds).NotEmpty().NotNull().WithMessage("dspIds is required and cannot be null")
                .Must(list => list.Count >= 0 ).WithMessage("dspIds must contain at least one id");

            RuleFor(x => x.TrackId).NotEmpty().NotNull().WithMessage("TrackId is required and cannot be null");
        }
    }
}
