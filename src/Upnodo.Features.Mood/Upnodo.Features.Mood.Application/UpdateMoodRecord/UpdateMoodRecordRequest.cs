using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordRequest
    {
        public MoodStatus MoodStatus { get; set; }
        
        public string MoodRecordId { get; set; }
    }
}