using System.Threading.Tasks;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class AlterMoodRecordService : IService<AlterMoodRecordResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public AlterMoodRecordService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<AlterMoodRecordResponse> RunAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}