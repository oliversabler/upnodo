namespace Upnodo.BuildingBlocks.Application.Configurations
{
    public class UpnodoDatabaseSettings : IUpnodoDatabaseSettings
    {
        public string ConnectionString { get; set; } = default!;
        
        public string DatabaseName { get; set; } = default!;
        
        public string MoodsCollectionName { get; set; } = default!;
        
        public string UsersCollectionName { get; set; } = default!;
    }
}