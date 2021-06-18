using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.Mood.Application.DeleteMoodRecord
{
    public class DeleteMoodRecordHandler : IRequestHandler<DeleteMoodRecordCommand, DeleteMoodRecordResponse>
    {
        private readonly IService<DeleteMoodRecordResponse> _deleteMoodRecordService;
        private readonly ILogger<DeleteMoodRecordHandler> _logger;

        public DeleteMoodRecordHandler(
            IService<DeleteMoodRecordResponse> deleteMoodRecordService,
            ILogger<DeleteMoodRecordHandler> logger)
        {
            _deleteMoodRecordService = deleteMoodRecordService;
            _logger = logger;
        }

        public async Task<DeleteMoodRecordResponse> Handle(DeleteMoodRecordCommand request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteMoodRecordHandler)} running.");
            return await _deleteMoodRecordService.RunAsync(request, token);
        }
    }
}