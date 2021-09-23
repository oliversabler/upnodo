using System;
using MediatR;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string UserId { get; }

        public string Username { get; }

        public string Email { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Fullname { get; }

        public DateTime DateCreated { get; }

        public CreateUserCommand(string username, string email, string firstname, string lastname)
        {
            UserId = Guid.NewGuid().ToString();
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Fullname = $"{firstname} {lastname}";
            DateCreated = DateTime.UtcNow;
        }
    }
}