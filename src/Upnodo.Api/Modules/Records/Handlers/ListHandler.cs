using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Domain.Queries.Records;
using Upnodo.Domain.Responses.Records;

namespace Upnodo.Api.Modules.Records.Handlers
{
    public class ListHandler : IRequestHandler<ListQuery, ListResponse>
    {
        private readonly IRecord<ListResponse> _listService;

        public ListHandler(IRecord<ListResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListResponse> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}