using System.Collections.Generic;
using Upnodo.Features.Mood.Tests.Models.Common;

namespace Upnodo.Features.Mood.Tests.Models
{
    public class GetMoodRecordsByUserId
    {
        public bool Success { get; set; }

        public List<MoodRecord> Value { get; set; }
    }
}