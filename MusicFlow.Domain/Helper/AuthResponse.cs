using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Dto
{
    public class AuthResponse
    {
        public string? Token { get; set; }
        public DateTime? TokenExpiryTime { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public bool? IsAuthenticated { get; set; }
    }
}
