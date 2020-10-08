namespace Upnodo.Api.Features.Mood.Configurations
{
    public interface IMoodDatabaseSettings
    {
        public string MoodsCollectionName { get; set; }
        
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
    }
}