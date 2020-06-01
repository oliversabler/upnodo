namespace Upnodo.Features.Mood.Application.SaveMood
{
    public class SaveMoodRequest
    {
        public string UserId { get; set; }
        
        public Domain.Mood Mood { get; set; }
    }
}