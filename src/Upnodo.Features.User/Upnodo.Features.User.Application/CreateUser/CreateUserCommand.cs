using System;
using MediatR;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Alias { get; }

        public DateTime Date { get; }
        
        public string Email { get; }

        public string Firstname { get; }
        
        public string UserId { get; }
        
        public string Lastname { get; }
        
        public CreateUserCommand(string alias, string email, string firstname, string lastname)
        {
            Alias = alias;
            Date = DateTime.UtcNow;
            Email = email;
            Firstname = firstname;
            UserId = Guid.NewGuid().ToString();
            Lastname = lastname;
        }
    }
}