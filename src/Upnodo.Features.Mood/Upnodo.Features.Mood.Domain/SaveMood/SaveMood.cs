using System.Collections.Generic;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    public class SaveMood
    {
        public SaveMood()
        {
            if (Records == null)
            {
                Records = new List<SaveMoodRecord>();
            }
        }
        
        public List<SaveMoodRecord> Records { get; set; }
    }
}