using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
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

        public async Task<CreateMoodRecordResponse> Handle(CreateMoodRecordCommand request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(CreateMoodRecordHandler)} running.");
            return await _createMoodRecordService.RunAsync(request, token);
        }
    }
}