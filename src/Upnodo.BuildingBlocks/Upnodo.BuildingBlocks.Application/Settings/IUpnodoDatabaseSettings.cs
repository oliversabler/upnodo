namespace Upnodo.BuildingBlocks.Application.Settings
{
    public interface IUpnodoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
        
        public string MoodsCollectionName { get; set; }

        public string UsersCollectionName { get; set; }
    }
}