using System.Threading.Tasks;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetAllMoodRecordsService : IService<GetAllMoodRecordsResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public GetAllMoodRecordsService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<GetAllMoodRecordsResponse> RunAsync<T>(T request)
        {
            var records = _tempDbContext.GetAllMoodRecords();

            return Task.FromResult(new GetAllMoodRecordsResponse(true, records));
        }
    }
}