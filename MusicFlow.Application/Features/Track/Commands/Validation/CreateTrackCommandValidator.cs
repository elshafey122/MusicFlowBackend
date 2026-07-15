using FluentValidation;
using MusicFlow.Application.Features.Artist.Commands.Model;
using MusicFlow.Application.Features.Track.Commands.Model;

namespace MusicFlow.Application.Features.Track.Commands.Validation
{
    public class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
    {
        public CreateTrackCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required and cannot be null");
            RuleFor(x => x.ArtistId).NotEmpty().NotNull().WithMessage("ArtistId is required and cannot be null");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("Status is required and cannot be null");
            RuleFor(x => x.Genre).NotEmpty().NotNull().WithMessage("Genre is required and cannot be null");
            RuleFor(x => x.ISRC).NotEmpty().NotNull().WithMessage("ISRC is required and cannot be null");
            RuleFor(x => x.ReleaseDate).NotEmpty().NotNull().WithMessage("ReleaseDate is required and cannot be null");
        }
    }
}
