using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetAllMoodRecordsService : IService<GetAllMoodRecordsResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public GetAllMoodRecordsService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<GetAllMoodRecordsResponse> RunAsync<T>(T request)
        {
            throw new NotImplementedException();
        }
    }
}