using FluentValidation;
using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Auth.Commands.Model;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Auth.Commands.Handler
{
    public class AuthCommandHandler : ResponseHandler, IRequestHandler<RegisterUserCommand, Response<string>>,
                                                         IRequestHandler<LoginUserCommand, Response<AuthResponse>>
    {
        private readonly IValidator<RegisterUserCommand> _registervalidator;
        private readonly IValidator<LoginUserCommand> _loginValidator;
        private readonly IAuthService _authService;
        public AuthCommandHandler(IValidator<RegisterUserCommand> registervalidator, IValidator<LoginUserCommand> loginValidator, IAuthService authService)
        {
            _registervalidator  = registervalidator;
            _loginValidator = loginValidator;
            _authService = authService;
        }
        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = await _registervalidator.ValidateAsync(request);
            if (!validator.IsValid)
            {
                var errorMessages = string.Join('-', validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<string>(errorMessages);
            }
            var user = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await _authService.Register(user, request.Password);
            
            return result switch
            {
                "Exists" => BadRequest<string>("user already exists"),
                "Created" => Created<string>(null),
                _ => BadRequest<string>("failed to register user")
            };
        }


        public async Task<Response<AuthResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = await _loginValidator.ValidateAsync(request);
            if (!validator.IsValid)
            {
                var errorMessages = string.Join('-', validator.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest<AuthResponse>(errorMessages);
            }
            var result = await _authService.Login(request.Email, request.password);
            if (result.IsAuthenticated != true)
            {
                return NotFound<AuthResponse>("Email or Password is not correct");
            }
            return Success<AuthResponse>(result);
        }
    }
}
