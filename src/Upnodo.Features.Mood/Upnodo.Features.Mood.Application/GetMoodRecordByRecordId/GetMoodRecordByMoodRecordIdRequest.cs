using System.ComponentModel.DataAnnotations;
using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.Features.Mood.Application.GetMoodRecordByRecordId
{
    public class GetMoodRecordByMoodRecordIdRequest
    {
        public GetMoodRecordByMoodRecordIdRequest(string moodRecordId, Cache? cache)
        {
            MoodRecordId = moodRecordId;
            Cache = cache;
        }
        
        [Required]
        public string MoodRecordId { get; }

        public Cache? Cache { get; }
    }
}