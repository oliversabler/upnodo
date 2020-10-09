using System;
using System.Collections.Generic;
using MediatR;

namespace Upnodo.Features.User.Application.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserCommand(string alias, string email, string firstname, string lastname)
        {
            Alias = alias;
            Date = DateTime.UtcNow;
            Email = email;
            Firstname = firstname;
            Guid = Guid.NewGuid();
            Lastname = lastname;
            MoodRecordGuids = new List<Guid>();
        }
        
        public string Alias { get; }

        public DateTime Date { get; }
        
        public string Email { get; }

        public string Firstname { get; }
        
        public Guid Guid { get; }
        
        public string Lastname { get; }

        public List<Guid> MoodRecordGuids { get; set; }
    }
}