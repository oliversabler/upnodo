namespace Upnodo.Infrastructure.Repositories
{
    public class DbSettings : IDbSettings
    {
        public string CollectionName { get; set; }
        
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
    }
}