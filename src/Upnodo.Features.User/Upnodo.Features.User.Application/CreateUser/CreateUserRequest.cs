using System.ComponentModel.DataAnnotations;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
    }
}