using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class DeleteMoodRecordHandler : IRequestHandler<DeleteMoodRecordCommand, DeleteMoodRecordResponse>
    {
        private readonly IService<DeleteMoodRecordResponse> _deleteMoodRecordService;

        public DeleteMoodRecordHandler(IService<DeleteMoodRecordResponse> deleteMoodRecordService)
        {
            _deleteMoodRecordService = deleteMoodRecordService;
        }

        public async Task<DeleteMoodRecordResponse> Handle(DeleteMoodRecordCommand request, CancellationToken cancellationToken)
        {
            return await _deleteMoodRecordService.RunAsync(request);
        }
    }
}