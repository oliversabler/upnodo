using System;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordCommand : IRequest<UpdateMoodRecordResponse>
    {
        public UpdateMoodRecordCommand(MoodStatus moodStatus, string moodRecordId)
        {
            DateUpdate = DateTime.UtcNow;
            MoodStatus = moodStatus;
            MoodRecordId = moodRecordId;
        }

        public DateTime DateUpdate { get; }
        
        public MoodStatus MoodStatus { get; }
        
        public string MoodRecordId { get; }

    }
}