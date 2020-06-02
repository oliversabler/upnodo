namespace Upnodo.Features.Mood.Infrastructure
{
    public interface ITempDbContext
    {
        void CreateMoodRecord(string value);

        string GetAllMoodRecords();

        string GetMoodRecordsByUserId(string userId);
    }
}