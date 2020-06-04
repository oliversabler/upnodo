using System;

namespace Upnodo.Features.Mood.Infrastructure
{
    public interface ITempDbContext
    {
        void CreateMoodRecord(string value);

        void DeleteMoodRecord(Guid guid);

        string GetAllMoodRecords();

        string GetMoodRecordsByUserId(string userId);
    }
}