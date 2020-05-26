using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records.Handlers
{
    public class ListAllRecordsHandler : IRequestHandler<ListAllRecordsQuery, ListAllRecordsResponse>
    {
        private readonly IService<ListAllRecordsResponse> _listService;

        public ListAllRecordsHandler(IService<ListAllRecordsResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListAllRecordsResponse> Handle(ListAllRecordsQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}