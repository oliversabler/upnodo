using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteAllMoodRecordsService : IService<DeleteAllMoodRecordsResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<DeleteMoodRecordService> _logger;

        public DeleteAllMoodRecordsService(
            MongoDbRepository mongoDbRepository,
            ILogger<DeleteMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<DeleteAllMoodRecordsResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(DeleteAllMoodRecordsService)} running.");

            if (request is not DeleteAllMoodRecordsCommand command)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(DeleteAllMoodRecordsCommand)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteAllMoodRecordsCommand)}");
            }

            await _mongoDbRepository.DeleteAllAsync();

            return new DeleteAllMoodRecordsResponse(true, string.Empty);
        }
    }
}