using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteMoodRecordService : IService<DeleteMoodRecordResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<DeleteMoodRecordService> _logger;

        public DeleteMoodRecordService(
            MongoDbRepository mongoDbRepository,
            ILogger<DeleteMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<DeleteMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(DeleteMoodRecordService)} running.");

            if (request is not DeleteMoodRecordCommand command)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(DeleteMoodRecordCommand)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteMoodRecordCommand)}");
            }

            await _mongoDbRepository.DeleteAsync(command.MoodId);

            return new DeleteMoodRecordResponse(true, string.Empty);
        }
    }
}