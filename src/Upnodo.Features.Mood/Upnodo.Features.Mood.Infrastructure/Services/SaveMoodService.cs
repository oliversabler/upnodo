using System.Text.Json;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class SaveMoodService : IService<SaveMoodResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public SaveMoodService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<SaveMoodResponse> RunAsync<T>(T request)
        {
            var requestAsJson = JsonSerializer.Serialize(request);
            
            _tempDbContext.SaveMood(requestAsJson);

            return Task.FromResult(new SaveMoodResponse(true, requestAsJson));
        }
    }
}