namespace Upnodo.Api.Configurations
{
    public class UpnodoDatabaseSettings : IUpnodoDatabaseSettings
    {
        public string MoodsCollectionName { get; set; }
        
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
    }
}