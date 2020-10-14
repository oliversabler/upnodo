using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordCommand : IRequest<UpdateMoodRecordResponse>
    {
        public UpdateMoodRecordCommand(Domain.Mood mood, string moodRecordId)
        {
            DateUpdate = DateTime.UtcNow;
            Mood = mood;
            MoodRecordId = moodRecordId;
        }

        public DateTime DateUpdate { get; }
        
        public Domain.Mood Mood { get; }
        
        public string MoodRecordId { get; }

    }
}