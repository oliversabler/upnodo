namespace Upnodo.BuildingBlocks.Application.Abstractions
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string MoodsCollectionName { get; set; }

        public string UsersCollectionName { get; set; }
    }
}