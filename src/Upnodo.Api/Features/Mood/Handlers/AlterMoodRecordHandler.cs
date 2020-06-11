using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class AlterMoodRecordHandler : IRequestHandler<AlterMoodRecordCommand, AlterMoodRecordResponse>
    {
        private readonly AlterMoodRecordService _alterMoodRecordService;

        public AlterMoodRecordHandler(AlterMoodRecordService alterMoodRecordService)
        {
            _alterMoodRecordService = alterMoodRecordService;
        }

        public async Task<AlterMoodRecordResponse> Handle(AlterMoodRecordCommand request, CancellationToken cancellationToken)
        {
            return await _alterMoodRecordService.RunAsync(request);
        }
    }
}