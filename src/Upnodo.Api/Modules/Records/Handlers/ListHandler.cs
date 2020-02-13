using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records.Handlers
{
    public class ListHandler : IRequestHandler<ListQuery, ListResponse>
    {
        private readonly IService<ListResponse> _listService;

        public ListHandler(IService<ListResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListResponse> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}