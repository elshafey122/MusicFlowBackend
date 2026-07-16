using FluentValidation;
using MusicFlow.Application.Features.Auth.Commands.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Validation
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Email is required and cannot be null");
            RuleFor(x => x.password).NotEmpty().NotNull().WithMessage("password is required and cannot be null");
        }
    }
}
