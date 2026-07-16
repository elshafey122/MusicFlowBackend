using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Domain.Helper
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }
    }
}
