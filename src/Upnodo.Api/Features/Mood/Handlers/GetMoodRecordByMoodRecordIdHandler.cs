using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetMoodRecordByMoodRecordIdHandler : IRequestHandler<GetMoodRecordByMoodRecordIdQuery, GetMoodRecordByMoodRecordIdResponse>
    {
        private readonly IService<GetMoodRecordByMoodRecordIdResponse> _getMoodRecordByMoodRecordIdService;

        public GetMoodRecordByMoodRecordIdHandler(IService<GetMoodRecordByMoodRecordIdResponse> getMoodRecordByMoodRecordIdService)
        {
            _getMoodRecordByMoodRecordIdService = getMoodRecordByMoodRecordIdService;
        }

        public async Task<GetMoodRecordByMoodRecordIdResponse> Handle(GetMoodRecordByMoodRecordIdQuery request, CancellationToken token)
        {
            return await _getMoodRecordByMoodRecordIdService.RunAsync(request, token);
        }
    }
}