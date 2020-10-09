using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.AlterMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class AlterMoodRecordHandler : IRequestHandler<AlterMoodRecordCommand, AlterMoodRecordResponse>
    {
        private readonly IService<AlterMoodRecordResponse> _alterMoodRecordService;

        public AlterMoodRecordHandler(IService<AlterMoodRecordResponse> alterMoodRecordService)
        {
            _alterMoodRecordService = alterMoodRecordService;
        }

        public async Task<AlterMoodRecordResponse> Handle(AlterMoodRecordCommand request, CancellationToken cancellationToken)
        {
            return await _alterMoodRecordService.RunAsync(request);
        }
    }
}