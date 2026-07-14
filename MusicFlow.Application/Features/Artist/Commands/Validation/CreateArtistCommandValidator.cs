using FluentValidation;
using MusicFlow.Application.Features.Artist.Commands.Model;

namespace MusicFlow.Application.Features.Artist.Commands.Validation
{
    public class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommand>
    {
        public CreateArtistCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("name is required and cannot be null");
            RuleFor(x => x.Country).NotEmpty().NotNull().WithMessage("price is required and cannot be null");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("email is required and cannot be null").EmailAddress().WithMessage("enter a valid email");
        }
    }
}
