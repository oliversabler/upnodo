using System.ComponentModel.DataAnnotations;

namespace Upnodo.Features.User.Application.UpdateUser
{
    public class UpdateUserRequest
    {
        [Required]
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}