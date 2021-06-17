using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class UpdateMoodRecordService : IService<UpdateMoodRecordResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<UpdateMoodRecordService> _logger;

        public UpdateMoodRecordService(
            MongoDbRepository mongoDbRepository,
            ILogger<UpdateMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<UpdateMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(UpdateMoodRecordService)} running.");

            if (request is not UpdateMoodRecordCommand command)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(UpdateMoodRecordCommand)}");
                
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(UpdateMoodRecordCommand)}");
            }

            var moodRecord = MoodRecord.UpdateMood(
                command.MoodRecordId,
                command.DateUpdate,
                command.MoodStatus);

            var response = await _mongoDbRepository.UpdateAsync(moodRecord);

            return new UpdateMoodRecordResponse(true, response);
        }
    }
}