using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Interfaces;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MusicFlow.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponse> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return new AuthResponse() { IsAuthenticated = false };
            }
            var accessTokenExpiry = DateTime.UtcNow.AddMinutes(20);
            var refreshTokenExpiry = DateTime.UtcNow.AddHours(12);
            var claims = await GenerateClaims(user);
            var (accessToken, tokenExpirationTime) = GenerateToken(user, claims, accessTokenExpiry);

            await updateUser(user, accessToken, accessTokenExpiry);

            return new AuthResponse()
            {
                Token = accessToken,
                IsAuthenticated = true,
                TokenExpiryTime = tokenExpirationTime,
                UserName = user.UserName,
                UserId = user.Id,
            };
        }

        public async Task<string> Register(User user, string password)
        {
            try
            {
                var EmailFound = await _userManager.FindByEmailAsync(user.Email);
                if (EmailFound != null)
                {
                    return "Exists";
                }
                var UserNameFound = await _userManager.Users.FirstOrDefaultAsync(s => s.UserName == user.UserName);
                if (UserNameFound != null)
                {
                    return "Exists";
                }
                var create = await _userManager.CreateAsync(user, password);
                if (create.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    return "Created";
                }
                return "Failed";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            return "";
        }

        private async Task updateUser(User user, string accessToken, DateTime accessTokenExpiry)
        {
            user.Token = accessToken;
            user.TokenExpiryTime = accessTokenExpiry;
            await _userManager.UpdateAsync(user);
        }


        private async Task<IEnumerable<Claim>> GenerateClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email.ToString()),
                new Claim(ClaimTypes.Name,user.UserName.ToString()),
            };
            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            claims.AddRange(userClaims);
            return claims;
        }

        private (string, DateTime) GenerateToken(User user, IEnumerable<Claim> claims, DateTime accessTokenExpirtyDate)
        {
            var jwttoken = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: accessTokenExpirtyDate,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secret"])), SecurityAlgorithms.HmacSha256)
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwttoken);
            var tokenExpiry = jwttoken.ValidTo;
            return (accessToken, tokenExpiry);
        }

        public async Task<UserDto> GetCurrentUser(string Id)
        {

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return null;
            }
            var userroles = await _userManager.GetRolesAsync(user);
            return new UserDto
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Roles = userroles,
                Id = Id
            };
        }
    }
}
