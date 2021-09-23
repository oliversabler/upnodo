using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.CreateMoodRecord
{
    public class CreateMoodRecordHandler : IRequestHandler<CreateMoodRecordCommand, CreateMoodRecordResponse>
    {
        private readonly IService<CreateMoodRecordResponse> _createMoodRecordService;
        private readonly ILogger<CreateMoodRecordHandler> _logger;

        public CreateMoodRecordHandler(
            IService<CreateMoodRecordResponse> createMoodRecordService,
            ILogger<CreateMoodRecordHandler> logger)
        {
            _createMoodRecordService = createMoodRecordService;
            _logger = logger;
        }

        public async Task<CreateMoodRecordResponse> Handle(CreateMoodRecordCommand command, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(CreateMoodRecordHandler)} running.");

            var moodRecord = MoodRecord.CreateMood(
                command.MoodRecordId,
                command.DateCreated,
                DateTime.MinValue,
                command.MoodStatus,
                command.UserId,
                command.Username,
                command.Email,
                command.Firstname,
                command.Lastname);

            return await _createMoodRecordService.RunAsync(moodRecord, token);
        }
    }
}