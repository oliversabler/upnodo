using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordCommand : IRequest<UpdateMoodRecordResponse>
    {
        [Required]
        public string MoodRecordId { get; }

        public DateTime DateUpdate { get; }

        public MoodStatus MoodStatus { get; }


        public UpdateMoodRecordCommand(string moodRecordId, MoodStatus moodStatus)
        {
            MoodRecordId = moodRecordId;
            DateUpdate = DateTime.UtcNow;
            MoodStatus = moodStatus;
        }
    }
}