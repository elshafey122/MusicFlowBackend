using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Auth.Commands.Model
{
    public class RegisterUserCommand : IRequest<Response<string>>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
