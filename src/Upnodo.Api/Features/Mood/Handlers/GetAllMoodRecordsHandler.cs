using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class GetAllMoodRecordsHandler : IRequestHandler<GetAllMoodRecordsQuery, GetAllMoodRecordsResponse>
    {
        private readonly IService<GetAllMoodRecordsResponse> _getAllMoodRecordsService;

        public GetAllMoodRecordsHandler(IService<GetAllMoodRecordsResponse> getAllMoodRecordsService)
        {
            _getAllMoodRecordsService = getAllMoodRecordsService;
        }

        public async Task<GetAllMoodRecordsResponse> Handle(GetAllMoodRecordsQuery request, CancellationToken cancellationToken)
        {
            return await _getAllMoodRecordsService.RunAsync(request);
        }
    }
}