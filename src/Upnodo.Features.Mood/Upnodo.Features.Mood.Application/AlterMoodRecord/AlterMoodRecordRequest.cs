using System;

namespace Upnodo.Features.Mood.Application.AlterMoodRecord
{
    public class AlterMoodRecordRequest
    {
        public Guid Guid { get; set; }

        public Domain.Mood Mood { get; set; }
    }
}