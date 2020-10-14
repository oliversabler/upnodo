namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordRequest
    {
        public Domain.Mood Mood { get; set; }
        
        public string MoodRecordId { get; set; }
    }
}