using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetMoodRecordsByUserGuidHandler : IRequestHandler<GetMoodRecordsByUserGuidQuery, GetMoodRecordsByUserGuidResponse>
    {
        private readonly IService<GetMoodRecordsByUserGuidResponse> _getMoodRecordsByIdService;

        public GetMoodRecordsByUserGuidHandler(IService<GetMoodRecordsByUserGuidResponse> getMoodRecordsByIdService)
        {
            _getMoodRecordsByIdService = getMoodRecordsByIdService;
        }

        public async Task<GetMoodRecordsByUserGuidResponse> Handle(GetMoodRecordsByUserGuidQuery request, CancellationToken cancellationToken)
        {
            return await _getMoodRecordsByIdService.RunAsync(request);
        }
    }
}