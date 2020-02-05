using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Domain.Responses.Records;

namespace Upnodo.Infrastructure.Services.Records
{
    public class ListService : IService<ListResponse>
    {
        public Task<ListResponse> RunAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}