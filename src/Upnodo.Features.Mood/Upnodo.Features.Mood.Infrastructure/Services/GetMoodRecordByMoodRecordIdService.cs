using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordByMoodRecordIdService : IService<GetMoodRecordByMoodRecordIdResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public GetMoodRecordByMoodRecordIdService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<GetMoodRecordByMoodRecordIdResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not GetMoodRecordByMoodRecordIdQuery query)
            {
                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(GetMoodRecordByMoodRecordIdQuery)}");
            }

            var records = _moodRecordRepository.Read(query.MoodRecordId);

            return Task.FromResult(new GetMoodRecordByMoodRecordIdResponse(true, records));
        }
    }
}