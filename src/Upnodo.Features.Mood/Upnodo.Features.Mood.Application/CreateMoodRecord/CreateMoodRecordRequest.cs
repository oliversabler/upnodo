using System;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordRequest
    {
        public Guid UserId { get; set; }
        
        public Domain.Mood Mood { get; set; }
    }
}