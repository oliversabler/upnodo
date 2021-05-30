using System;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Tests.Models.Common
{
    public class MoodRecord
    {
        public DateTime Date { get; set; }

        public Guid Guid { get; set; }
        
        public MoodStatus MoodStatus { get; set; }

        public string UserId { get; set; }
    }
}