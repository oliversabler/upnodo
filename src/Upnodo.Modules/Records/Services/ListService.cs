using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class ListService : IService<ListResponse>
    {
        public Task<ListResponse> RunAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}