using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records.Handlers
{
    
    public class SaveRecordHandler : IRequestHandler<SaveRecordCommand, SaveRecordResponse>
    {
        private readonly IService<SaveRecordResponse> _saveService;

        public SaveRecordHandler(IService<SaveRecordResponse> saveService)
        {
            _saveService = saveService;
        }

        public async Task<SaveRecordResponse> Handle(SaveRecordCommand request, CancellationToken cancellationToken)
        {
            return await _saveService.RunAsync(request);
        }
    }
}