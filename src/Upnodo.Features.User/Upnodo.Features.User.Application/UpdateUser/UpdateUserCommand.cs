using System;
using MediatR;

namespace Upnodo.Features.User.Application.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public string UserId { get; }
        public string Username { get; }

        public string Email { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Fullname { get; set; }

        public DateTime DateUpdated { get; }

        public UpdateUserCommand(
            string username,
            string email,
            string firstname,
            string lastname,
            string userId)
        {
            Username = username;
            DateUpdated = DateTime.UtcNow;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            UserId = userId;
            Fullname = $"{firstname} {lastname}";
        }
    }
}