using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteMoodRecordService : IService<DeleteMoodRecordResponse>
    {
        // Todo: Implement tempDbContext
        public Task<DeleteMoodRecordResponse> RunAsync<T>(T request)
        {
            var requestAsJson = JsonSerializer.Serialize(request);

            return null;
        }
    }
}