using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.Mappers;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class CreateMoodRecordService : IService<CreateMoodRecordResponse>
    {
        private readonly MongoDbMoodRecordRepository _mongoDbRepository;
        private readonly ILogger<CreateMoodRecordService> _logger;

        public CreateMoodRecordService(
            MongoDbMoodRecordRepository mongoDbRepository,
            ILogger<CreateMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<CreateMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(CreateMoodRecordService)} running.");

            if (request is not MoodRecord moodRecord)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(MoodRecord)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(MoodRecord)}");
            }

            var response = await _mongoDbRepository.CreateAsync(MoodRecordMapper.GetDto(moodRecord));

            return new CreateMoodRecordResponse(true, response);
        }
    }
}