using System;

namespace Upnodo.Features.Mood.Tests.Models.Common
{
    public class MoodRecord
    {
        public DateTime Date { get; set; }

        public Guid Guid { get; set; }
        
        public Domain.Mood Mood { get; set; }

        public string UserId { get; set; }
    }
}