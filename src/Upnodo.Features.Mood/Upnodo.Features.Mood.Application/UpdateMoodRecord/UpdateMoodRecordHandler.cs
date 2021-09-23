using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Application.UpdateMoodRecord
{
    public class UpdateMoodRecordHandler : IRequestHandler<UpdateMoodRecordCommand, UpdateMoodRecordResponse>
    {
        private readonly IService<UpdateMoodRecordResponse> _updateMoodRecordService;
        private readonly ILogger<UpdateMoodRecordHandler> _logger;

        public UpdateMoodRecordHandler(
            IService<UpdateMoodRecordResponse> updateMoodRecordService,
            ILogger<UpdateMoodRecordHandler> logger)
        {
            _updateMoodRecordService = updateMoodRecordService;
            _logger = logger;
        }

        public async Task<UpdateMoodRecordResponse> Handle(UpdateMoodRecordCommand request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(UpdateMoodRecordHandler)} running.");

            var moodRecord = MoodRecord.UpdateMood(request.MoodRecordId, request.DateUpdate, request.MoodStatus);

            return await _updateMoodRecordService.RunAsync(moodRecord, token);
        }
    }
}