using System;
using System.Collections.Generic;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure
{
    public class DbContext : IDbContext
    {
        public string AlterMoodRecord(AlterMoodRecordCommand command)
        {
            throw new NotImplementedException();
        }

        public void CreateMoodRecord(string value)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoodRecord(Guid guid)
        {
            throw new NotImplementedException();
        }

        public string GetAllMoodRecords()
        {
            throw new NotImplementedException();
        }

        public List<MoodRecord> GetMoodRecordsByUserGuid(Guid userGuid)
        {
            throw new NotImplementedException();
        }
    }
}