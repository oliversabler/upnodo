using System.Text.Json.Serialization;

namespace Upnodo.BuildingBlocks.Application.Models
{
    public class Cache
    {
        [JsonIgnore]
        public string? CacheKey { get; set; }
        
        public bool BypassCache { get; set; }
    }
}