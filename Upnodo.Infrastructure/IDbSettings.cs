namespace Upnodo.Infrastructure
{
    public interface IDbSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}