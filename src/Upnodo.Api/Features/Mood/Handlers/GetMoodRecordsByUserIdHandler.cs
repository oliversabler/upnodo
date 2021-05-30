using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserId;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetMoodRecordsByUserIdHandler : IRequestHandler<GetMoodRecordsByUserIdQuery, GetMoodRecordsByUserIdResponse>
    {
        private readonly IService<GetMoodRecordsByUserIdResponse> _getMoodRecordsByIdService;

        public GetMoodRecordsByUserIdHandler(IService<GetMoodRecordsByUserIdResponse> getMoodRecordsByIdService)
        {
            _getMoodRecordsByIdService = getMoodRecordsByIdService;
        }

        public async Task<GetMoodRecordsByUserIdResponse> Handle(GetMoodRecordsByUserIdQuery request, CancellationToken token)
        {
            return await _getMoodRecordsByIdService.RunAsync(request, token);
        }
    }
}