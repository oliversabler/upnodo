using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetAllMoodRecordsService : IService<GetAllMoodRecordsResponse>
    {
        private readonly IDbContext _tempDbContext;

        public GetAllMoodRecordsService(IDbContext tempDbContext)
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