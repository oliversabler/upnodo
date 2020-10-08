using System;
using System.Collections.Generic;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure
{
    public interface IDbContext
    {
        string AlterMoodRecord(AlterMoodRecordCommand command);
        
        void CreateMoodRecord(string value);

        void DeleteMoodRecord(Guid guid);

        string GetAllMoodRecords();

        List<MoodRecord> GetMoodRecordsByUserGuid(Guid userGuid);
    }
}