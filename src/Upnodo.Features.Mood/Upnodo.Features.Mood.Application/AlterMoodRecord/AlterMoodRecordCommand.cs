using System;
using MediatR;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordCommand : IRequest<AlterMoodRecordResponse>
    {
        public AlterMoodRecordCommand(Domain.Mood mood, string moodRecordId)
        {
            DateUpdate = DateTime.UtcNow;
            Mood = mood;
            MoodRecordId = moodRecordId;
        }

        public DateTime DateUpdate { get; set; }
        
        public Domain.Mood Mood { get; }
        
        public string MoodRecordId { get; }

    }
}