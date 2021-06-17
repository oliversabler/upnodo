using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetLatestCreatedMoodRecordsService : IService<GetLatestCreatedMoodRecordsResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<GetMoodRecordByMoodRecordIdService> _logger;

        public GetLatestCreatedMoodRecordsService(
            MongoDbRepository mongoDbRepository,
            ILogger<GetMoodRecordByMoodRecordIdService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
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

            var records = await _mongoDbRepository.ReadLatestAsync(query.TotalNumberOfMoodRecords);

            return new GetLatestCreatedMoodRecordsResponse(true, records);
        }
    }
}