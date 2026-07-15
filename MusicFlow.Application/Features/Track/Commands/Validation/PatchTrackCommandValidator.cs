using FluentValidation;
using MusicFlow.Application.Features.Track.Commands.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Commands.Validation
{
    public class PatchTrackCommandValidator : AbstractValidator<PatchTrackCommand>
    {
        public PatchTrackCommandValidator()
        {
            RuleFor(x => x.trackId).NotEmpty().NotNull().WithMessage("trackId is required and cannot be null");

            RuleFor(x => x.status).NotEmpty().NotNull().WithMessage("status is required and cannot be null");
        }
    }
}
