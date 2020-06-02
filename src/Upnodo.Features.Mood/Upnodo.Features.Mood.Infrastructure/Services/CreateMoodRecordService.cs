using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class CreateMoodRecordService : IService<CreateMoodRecordResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public CreateMoodRecordService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<CreateMoodRecordResponse> RunAsync<T>(T request)
        {
            var requestAsJson = JsonSerializer.Serialize(request);
            
            _tempDbContext.CreateMoodRecord(requestAsJson);

            return Task.FromResult(new CreateMoodRecordResponse(true, requestAsJson));
        }
    }
}