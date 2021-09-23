using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.BuildingBlocks.Application.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; } = default!;

        public string DatabaseName { get; set; } = default!;

        public string MoodsCollectionName { get; set; } = default!;

        public string UsersCollectionName { get; set; } = default!;
    }
}