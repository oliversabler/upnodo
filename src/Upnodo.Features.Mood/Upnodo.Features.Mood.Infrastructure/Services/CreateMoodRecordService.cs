using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class CreateMoodRecordService : IService<CreateMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        private readonly ILogger<CreateMoodRecordService> _logger;

        public CreateMoodRecordService(
            MoodRecordRepository moodRecordRepository,
            ILogger<CreateMoodRecordService> logger)
        {
            _moodRecordRepository = moodRecordRepository;
            _logger = logger;
        }

        public Task<CreateMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(CreateMoodRecordService)} running.");

            if (request is not CreateMoodRecordCommand command)
            {
                _logger.LogError($"{nameof(request)} with body: {JsonSerializer.Serialize(request)} is not of type {typeof(CreateMoodRecordCommand)}");
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateMoodRecordCommand)}");
            }

            var moodRecord = MoodRecord.CreateMood(
                command.MoodRecordId,
                command.DateCreated,
                DateTime.MinValue,
                command.MoodStatus,
                command.UserId,
                command.Username,
                command.Email);

            var response = _moodRecordRepository.Create(moodRecord);

            return Task.FromResult(new CreateMoodRecordResponse(true, response));
        }
    }
}