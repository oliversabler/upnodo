using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordCommand : IRequest<CreateMoodRecordResponse>
    {  
        public DateTime DateCreated { get; }
        
        [Required]
        public MoodStatus MoodStatus { get; }
        
        public string MoodRecordId { get; }

        [Required]
        public string UserId { get; }
        
        public string Username { get; }
        
        public string Email { get; }
        
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

    }
}