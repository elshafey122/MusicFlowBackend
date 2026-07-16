using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Domain.Entites
{
    public class User : IdentityUser
    {
        public string? Token { get; set; }
        public DateTime? TokenExpiryTime { get; set; }
    }
}
