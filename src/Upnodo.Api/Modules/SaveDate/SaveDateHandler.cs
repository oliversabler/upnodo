using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Commands;
using Upnodo.Domain.Responses;
using Upnodo.Infrastructure.Services.SaveDate;

namespace Upnodo.Api.Modules.SaveDate
{
    public class SaveDateHandler : IRequestHandler<SaveDateCommand, SaveDateResponse>
    {
        private readonly ISaveDateService _service;

        public SaveDateHandler(ISaveDateService service)
        {
            _service = service;
        }

        public async Task<SaveDateResponse> Handle(SaveDateCommand request, CancellationToken cancellationToken)
        {
            return await _service.SaveAsync(request);
        }
    }
}