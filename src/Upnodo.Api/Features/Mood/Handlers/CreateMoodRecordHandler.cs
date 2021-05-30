using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class CreateMoodRecordHandler : IRequestHandler<CreateMoodRecordCommand, CreateMoodRecordResponse>
    {
        private readonly IService<CreateMoodRecordResponse> _createMoodRecordService;

        public CreateMoodRecordHandler(IService<CreateMoodRecordResponse> createMoodRecordService)
        {
            _createMoodRecordService = createMoodRecordService;
        }

        public async Task<CreateMoodRecordResponse> Handle(CreateMoodRecordCommand request, CancellationToken token)
        {
            return await _createMoodRecordService.RunAsync(request, token);
        }
    }
}