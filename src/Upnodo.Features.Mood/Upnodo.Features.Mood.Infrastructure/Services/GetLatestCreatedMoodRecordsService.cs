using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Infrastructure.Mappers;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetLatestCreatedMoodRecordsService : IService<GetLatestCreatedMoodRecordsResponse>
    {
        private readonly MongoDbMoodRecordRepository _mongoDbRepository;
        private readonly ILogger<GetMoodRecordByMoodRecordIdService> _logger;

        public GetLatestCreatedMoodRecordsService(
            MongoDbMoodRecordRepository mongoDbRepository,
            ILogger<GetMoodRecordByMoodRecordIdService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<GetLatestCreatedMoodRecordsResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(GetLatestCreatedMoodRecordsService)} running.");

            if (request is not int totalNumberOfMoodRecords)
            {
                _logger.LogError(
                    $"{nameof(request)} is not of type {typeof(int)}");

                throw new ArgumentException(
                    $"{nameof(request)} is not of type {typeof(int)}");
            }

            var response = await _mongoDbRepository.ReadLatestAsync(totalNumberOfMoodRecords);

            return new GetLatestCreatedMoodRecordsResponse(true, MoodRecordMapper.GetModelCollection(response));
        }
    }
}