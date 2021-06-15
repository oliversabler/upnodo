using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetMoodRecordByMoodRecordIdHandler :
        IRequestHandler<GetMoodRecordByMoodRecordIdQuery, GetMoodRecordByMoodRecordIdResponse>
    {
        private readonly IService<GetMoodRecordByMoodRecordIdResponse> _getMoodRecordByMoodRecordIdService;
        private readonly ILogger<GetMoodRecordByMoodRecordIdHandler> _logger;

        public GetMoodRecordByMoodRecordIdHandler(
            IService<GetMoodRecordByMoodRecordIdResponse> getMoodRecordByMoodRecordIdService,
            ILogger<GetMoodRecordByMoodRecordIdHandler> logger)
        {
            _getMoodRecordByMoodRecordIdService = getMoodRecordByMoodRecordIdService;
            _logger = logger;
        }

        public async Task<GetMoodRecordByMoodRecordIdResponse> Handle(
            GetMoodRecordByMoodRecordIdQuery request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(GetMoodRecordByMoodRecordIdHandler)} running.");
            return await _getMoodRecordByMoodRecordIdService.RunAsync(request, token);
        }
    }
}