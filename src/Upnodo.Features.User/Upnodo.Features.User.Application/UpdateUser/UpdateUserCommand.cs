using System;
using MediatR;

namespace Upnodo.Features.User.Application.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public string Alias { get; }

        public DateTime DateUpdated { get; }
        
        public string Email { get; }

        public string Firstname { get; }

        public string Lastname { get; }
        
        public string UserId { get; }
        
        public UpdateUserCommand(
            string alias, 
            string email, 
            string firstname, 
            string lastname, 
            string userId)
        {
            Alias = alias;
            DateUpdated = DateTime.UtcNow;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            UserId = userId;
        }
    }
}