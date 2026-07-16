using MediatR;
using MusicFlow.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Auth.Commands.Model
{
    public class LoginUserCommand : IRequest<Response<AuthResponse>>
    {
        public string Email { get; set; }
        public string password { get; set; }
    }
}
