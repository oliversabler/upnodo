using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        public MoodStatus MoodStatus { get; set; }
        
        public string UserId { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
    }
}