using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordByMoodRecordIdService : IService<GetMoodRecordByMoodRecordIdResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        private readonly ILogger<GetMoodRecordByMoodRecordIdService> _logger;

        public GetMoodRecordByMoodRecordIdService(
            MoodRecordRepository moodRecordRepository, 
            ILogger<GetMoodRecordByMoodRecordIdService> logger)
        {
            _moodRecordRepository = moodRecordRepository;
            _logger = logger;
        }

        public async Task<GetMoodRecordByMoodRecordIdResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetMoodRecordByMoodRecordIdService)} running.");

            if (request is not GetMoodRecordByMoodRecordIdQuery query)
            {
                _logger.LogError($"{nameof(request)} with body: {JsonSerializer.Serialize(request)} is not of type {typeof(GetMoodRecordByMoodRecordIdQuery)}");
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(GetMoodRecordByMoodRecordIdQuery)}");
            }

            var records = await _moodRecordRepository.ReadAsync(query.MoodRecordId);

            return new GetMoodRecordByMoodRecordIdResponse(true, records);
        }
    }
}