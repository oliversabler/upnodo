using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Domain.Responses.Records;

namespace Upnodo.Infrastructure.Services.Records
{
    public class SaveService : IRecord<SaveResponse>
    {
        public Task<SaveResponse> RunAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}