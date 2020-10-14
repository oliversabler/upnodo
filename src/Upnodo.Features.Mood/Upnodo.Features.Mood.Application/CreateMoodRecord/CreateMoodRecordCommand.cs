using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordCommand : IRequest<CreateMoodRecordResponse>
    {
        public CreateMoodRecordCommand(Domain.Mood mood, string userId)
        {            
            DateCreated = DateTime.UtcNow;
            Mood = mood;
            MoodRecordId = Guid.NewGuid().ToString();
            UserId = userId;
        }
        
        public DateTime DateCreated { get; }
        
        public Domain.Mood Mood { get; }
        
        public string MoodRecordId { get; }

        public string UserId { get; }
    }
}