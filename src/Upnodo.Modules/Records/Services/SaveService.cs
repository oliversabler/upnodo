using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Infrastructure;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class SaveService : IService<SaveResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public SaveService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<SaveResponse> RunAsync<T>(T request)
        {
            var saveRequestAsJson = JsonSerializer.Serialize(request);
            
            _tempDbContext.SaveRecord(saveRequestAsJson);

            return Task.FromResult(new SaveResponse(true, saveRequestAsJson));
        }
    }
}