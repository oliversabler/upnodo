using System;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    // Todo: Good name?
    public class MoodRecord
    {
        public DateTime Date { get; set; }

        public Guid Guid { get; set; }
        
        public Mood Mood { get; set; }

        public string UserId { get; set; }
    }
}