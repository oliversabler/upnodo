namespace Upnodo.Api.Features.Mood.Configurations
{
    public class MoodDatabaseSettings : IMoodDatabaseSettings
    {
        public string MoodsCollectionName { get; set; }
        
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
    }
}