using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.BuildingBlocks.Application.Abstractions
{
    public interface ICacheableQuery
    {
        public Cache? Cache { get; set; }
    }
}