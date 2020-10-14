namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordRequest
    {
        public Domain.Mood Mood { get; set; }
        
        public string MoodRecordId { get; set; }
    }
}