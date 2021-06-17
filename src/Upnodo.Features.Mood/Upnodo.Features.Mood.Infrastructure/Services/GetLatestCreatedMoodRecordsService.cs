using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetLatestCreatedMoodRecordsService : IService<GetLatestCreatedMoodRecordsResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        private readonly ILogger<GetMoodRecordByMoodRecordIdService> _logger;

        public GetLatestCreatedMoodRecordsService(
            MoodRecordRepository moodRecordRepository,
            ILogger<GetMoodRecordByMoodRecordIdService> logger)
        {
            _moodRecordRepository = moodRecordRepository;
            _logger = logger;
        }

        public async Task<GetLatestCreatedMoodRecordsResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetLatestCreatedMoodRecordsService)} running.");

            if (request is not GetLatestCreatedMoodRecordsQuery query)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(GetLatestCreatedMoodRecordsQuery)}");

                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(GetLatestCreatedMoodRecordsQuery)}");
            }

            var records = await _moodRecordRepository.ReadLatestAsync(query.TotalNumberOfMoodRecords);

            return new GetLatestCreatedMoodRecordsResponse(true, records);
        }
    }
}