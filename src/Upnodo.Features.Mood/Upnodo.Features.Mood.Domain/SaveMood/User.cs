using System.Collections.Generic;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    // Todo: Where to put?
    public class User
    {
        public User()
        {
            if (MoodRecords == null)
            {
                MoodRecords = new List<MoodRecord>();
            }
        }
        
        public List<MoodRecord> MoodRecords { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
    }
}