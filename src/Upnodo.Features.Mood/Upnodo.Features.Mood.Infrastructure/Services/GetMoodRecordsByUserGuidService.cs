using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordsByUserGuidService : IService<GetMoodRecordsByUserGuidResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public GetMoodRecordsByUserGuidService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<GetMoodRecordsByUserGuidResponse> RunAsync<T>(T request)
        {
            if (!(request is GetMoodRecordsByUserGuidQuery query))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(GetMoodRecordsByUserGuidQuery)}");
            }
            
            var records = _moodRecordRepository.Read(query.UserId);

            return Task.FromResult(new GetMoodRecordsByUserGuidResponse(true, records));
        }
    }
}