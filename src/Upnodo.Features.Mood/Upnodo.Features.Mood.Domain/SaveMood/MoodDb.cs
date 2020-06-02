using System.Collections.Generic;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    public class MoodDb
    {
        public MoodDb()
        {
            if (Records == null)
            {
                Records = new List<SaveMoodRecord>();
            }
        }
        
        public List<SaveMoodRecord> Records { get; set; }
    }
}