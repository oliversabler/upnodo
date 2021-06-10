using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class UpdateMoodRecordService : IService<UpdateMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        private readonly ILogger<UpdateMoodRecordService> _logger;

        public UpdateMoodRecordService(
            MoodRecordRepository moodRecordRepository, 
            ILogger<UpdateMoodRecordService> logger)
        {
            _moodRecordRepository = moodRecordRepository;
            _logger = logger;
        }

        public Task<UpdateMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(UpdateMoodRecordService)} running.");

            if (request is not UpdateMoodRecordCommand command)
            {
                _logger.LogError($"{nameof(request)} with body: {JsonSerializer.Serialize(request)} is not of type {typeof(UpdateMoodRecordCommand)}");
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(UpdateMoodRecordCommand)}");
            }

            var moodRecord = MoodRecord.UpdateMood(
                command.MoodRecordId,
                command.DateUpdate,
                command.MoodStatus);

            var response = _moodRecordRepository.Update(moodRecord);

            return Task.FromResult(new UpdateMoodRecordResponse(true, response));
        }
    }
}