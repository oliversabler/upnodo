using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records.Handlers
{
    
    public class SaveHandler : IRequestHandler<SaveCommand, SaveResponse>
    {
        private readonly IService<SaveResponse> _saveService;

        public SaveHandler(IService<SaveResponse> saveService)
        {
            _saveService = saveService;
        }

        public async Task<SaveResponse> Handle(SaveCommand request, CancellationToken cancellationToken)
        {
            return await _saveService.RunAsync(request);
        }
    }
}