using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordRequest
    {
        [Required]
        [NotNull, DisallowNull]
        public MoodStatus MoodStatus { get; }

        [Required]
        [NotNull, DisallowNull]
        public string MoodRecordId { get; }
        
        public UpdateMoodRecordRequest(MoodStatus moodStatus, string moodRecordId)
        {
            MoodStatus = moodStatus;
            MoodRecordId = moodRecordId;
        }
    }
}