namespace Upnodo.BuildingBlocks.Application.Configurations
{
    public interface IUpnodoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
        
        public string MoodsCollectionName { get; set; }

        public string UsersCollectionName { get; set; }
    }
}