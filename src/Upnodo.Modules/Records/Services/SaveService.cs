using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class SaveService : IService<SaveResponse>
    {
        public Task<SaveResponse> RunAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}