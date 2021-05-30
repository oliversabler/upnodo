using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserId;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordsByUserIdService : IService<GetMoodRecordsByUserIdResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public GetMoodRecordsByUserIdService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<GetMoodRecordsByUserIdResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not GetMoodRecordsByUserIdQuery query)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(GetMoodRecordsByUserIdQuery)}");
            }
            
            var records = _moodRecordRepository.Read(query.UserId);

            // Todo: If records is empty we should return false with describing message
            return Task.FromResult(new GetMoodRecordsByUserIdResponse(true, records));
        }
    }
}