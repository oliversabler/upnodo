using System;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordCommand : IRequest<CreateMoodRecordResponse>
    {
        public CreateMoodRecordCommand(
            MoodStatus moodStatus, 
            string userId, 
            string username, 
            string email)
        {            
            DateCreated = DateTime.UtcNow;
            MoodStatus = moodStatus;
            MoodRecordId = Guid.NewGuid().ToString();
            UserId = userId;
            Username = username;
            Email = email;
        }
        
        public DateTime DateCreated { get; }
        
        public MoodStatus MoodStatus { get; }
        
        public string MoodRecordId { get; }

        public string UserId { get; }
        
        public string Username { get; }
        
        public string Email { get; }
    }
}