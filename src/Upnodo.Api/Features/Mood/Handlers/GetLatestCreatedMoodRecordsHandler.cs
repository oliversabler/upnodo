using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetLatestCreatedMoodRecordsHandler :
        IRequestHandler<GetLatestCreatedMoodRecordsQuery, GetLatestCreatedMoodRecordsResponse>
    {
        private readonly IService<GetLatestCreatedMoodRecordsResponse> _getLatestCreatedMoodRecordsService;
        private readonly ILogger<GetLatestCreatedMoodRecordsHandler> _logger;

        public GetLatestCreatedMoodRecordsHandler(
            IService<GetLatestCreatedMoodRecordsResponse> getLatestCreatedMoodRecordsService,
            ILogger<GetLatestCreatedMoodRecordsHandler> logger)
        {
            _getLatestCreatedMoodRecordsService = getLatestCreatedMoodRecordsService;
            _logger = logger;
        }

        public async Task<GetLatestCreatedMoodRecordsResponse> Handle(
            GetLatestCreatedMoodRecordsQuery request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(GetLatestCreatedMoodRecordsHandler)} running.");
            return await _getLatestCreatedMoodRecordsService.RunAsync(request, token);
        }
    }
}