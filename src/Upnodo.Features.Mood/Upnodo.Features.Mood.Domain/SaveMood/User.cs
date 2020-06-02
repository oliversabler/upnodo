using System.Collections.Generic;

namespace Upnodo.Features.Mood.Domain.SaveMood
{
    // Todo: Where to put?
    public class User
    {
        public User()
        {
            if (Records == null)
            {
                Records = new List<SaveMoodRecord>();
            }
        }
        
        public List<SaveMoodRecord> Records { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
    }
}