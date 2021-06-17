using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
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
            return await _updateMoodRecordService.RunAsync(request, token);
        }
    }
}