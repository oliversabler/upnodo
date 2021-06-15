namespace Upnodo.BuildingBlocks.Application.Contracts
{
    public interface ICacheableQuery
    {
        public string CacheKey { get; }
        
        public bool BypassCache { get; }
    }
}