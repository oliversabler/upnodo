using System;

namespace Upnodo.Features.User.Infrastructure.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Fullname { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
