using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordCommand : IRequest<CreateMoodRecordResponse>
    {
        public CreateMoodRecordCommand(Domain.Mood mood, Guid userGuid)
        {            
            Date = DateTime.UtcNow;
            Guid = Guid.NewGuid();
            Mood = mood;
            UserGuid = userGuid;
        }
        
        public Guid Guid { get; }

        public DateTime Date { get; }

        public Domain.Mood Mood { get; }
        
        public Guid UserGuid { get; }
    }
}