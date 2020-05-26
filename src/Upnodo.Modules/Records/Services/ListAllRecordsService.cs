using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Infrastructure;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class ListAllRecordsService : IService<ListAllRecordsResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public ListAllRecordsService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<ListAllRecordsResponse> RunAsync<T>(T request)
        {
            var records = _tempDbContext.ListAllRecords();

            return Task.FromResult(new ListAllRecordsResponse(true, records));
        }
    }
}