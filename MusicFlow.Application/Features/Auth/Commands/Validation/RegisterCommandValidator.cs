using FluentValidation;
using MusicFlow.Application.Features.Auth.Commands.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Validation
{
    public class RegisterCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("username is required and cannot be null");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Email is required and cannot be null");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("password is required and cannot be null")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters")

            .Matches("[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter")

            .Matches("[a-z]")
            .WithMessage("Password must contain at least one lowercase letter")

            .Matches("[0-9]")
            .WithMessage("Password must contain at least one number");

        }
    }
}
