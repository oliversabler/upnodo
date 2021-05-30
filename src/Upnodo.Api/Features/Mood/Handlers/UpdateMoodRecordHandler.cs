using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class UpdateMoodRecordHandler : IRequestHandler<UpdateMoodRecordCommand, UpdateMoodRecordResponse>
    {
        private readonly IService<UpdateMoodRecordResponse> _updateMoodRecordService;

        public UpdateMoodRecordHandler(IService<UpdateMoodRecordResponse> updateMoodRecordService)
        {
            _updateMoodRecordService = updateMoodRecordService;
        }

        public async Task<UpdateMoodRecordResponse> Handle(UpdateMoodRecordCommand request, CancellationToken token)
        {
            return await _updateMoodRecordService.RunAsync(request, token);
        }
    }
}