using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteMoodRecordService : IService<DeleteMoodRecordResponse>
    {
        private readonly MongoDbMoodRecordRepository _mongoDbRepository;
        private readonly ILogger<DeleteMoodRecordService> _logger;

        public DeleteMoodRecordService(
            MongoDbMoodRecordRepository mongoDbRepository,
            ILogger<DeleteMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<DeleteMoodRecordResponse> RunAsync<T>(T moodRecordId, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(DeleteMoodRecordService)} running.");

            if (moodRecordId is not string)
            {
                _logger.LogError(
                    $"{nameof(moodRecordId)} with id: {moodRecordId} " +
                    $"is not of type {typeof(string)}");

                throw new ArgumentException($"{nameof(moodRecordId)} is not of type {typeof(string)}");
            }

            await _mongoDbRepository.DeleteAsync(moodRecordId.ToString());

            return new DeleteMoodRecordResponse(true);
        }
    }
}