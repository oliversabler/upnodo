using System;
using Upnodo.Features.Mood.Application.AlterMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure
{
    public interface ITempDbContext
    {
        string AlterMoodRecord(AlterMoodRecordCommand command);
        
        void CreateMoodRecord(string value);

        void DeleteMoodRecord(Guid guid);

        string GetAllMoodRecords();

        string GetMoodRecordsByUserId(string userId);
    }
}