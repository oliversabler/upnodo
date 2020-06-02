namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        public string UserId { get; set; }
        
        public Domain.Mood Mood { get; set; }
    }
}