using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Infrastructure;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class SaveRecordService : IService<SaveRecordResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public SaveRecordService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<SaveRecordResponse> RunAsync<T>(T request)
        {
            var requestAsJson = JsonSerializer.Serialize(request);
            
            _tempDbContext.SaveRecord(requestAsJson);

            return Task.FromResult(new SaveRecordResponse(true, requestAsJson));
        }
    }
}