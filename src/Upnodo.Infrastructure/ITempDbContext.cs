namespace Upnodo.Infrastructure
{
    public interface ITempDbContext
    {
        string ListAllRecords();

        string ListRecordsByUserId(string userId);
        
        void SaveRecord(string value);
    }
}