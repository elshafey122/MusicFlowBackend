using MusicFlow.Application.Dto;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Interfaces
{
    public interface IAuthService 
    {
        public Task<string> Register(User user, string password);
        public Task<AuthResponse> Login(string email, string password);
        public Task<UserDto> GetCurrentUser(string Id);
    }
}
