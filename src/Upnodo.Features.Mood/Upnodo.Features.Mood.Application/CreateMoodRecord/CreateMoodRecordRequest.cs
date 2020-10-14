namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        public Domain.Mood Mood { get; set; }
        
        public string UserId { get; set; }
    }
}