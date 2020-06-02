using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.SaveMood
{
    public class SaveMoodCommand : IRequest<SaveMoodResponse>
    {
        public SaveMoodCommand(Domain.Mood mood, string userId)
        {
            UserId = userId;
            Guid = Guid.NewGuid();
            Mood = mood;
            Date = DateTime.UtcNow;
        }
        
        public Guid Guid { get; }

        public DateTime Date { get; }

        public Domain.Mood Mood { get; }
        
        public string UserId { get; }
    }
}