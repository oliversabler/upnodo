using Upnodo.BuildingBlocks.Application.Models;

namespace Upnodo.BuildingBlocks.Application.Contracts
{
    public interface ICacheableQuery
    {
        public Cache? Cache { get; set; }
    }
}