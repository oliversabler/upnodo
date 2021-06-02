using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordCommand : IRequest<UpdateMoodRecordResponse>
    {
        public DateTime DateUpdate { get; }
        
        public MoodStatus MoodStatus { get; }
        
        [Required]
        public string MoodRecordId { get; }
        
        public UpdateMoodRecordCommand(MoodStatus moodStatus, string moodRecordId)
        {
            DateUpdate = DateTime.UtcNow;
            MoodStatus = moodStatus;
            MoodRecordId = moodRecordId;
        }
    }
}