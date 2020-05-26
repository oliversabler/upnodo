using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records.Handlers
{
    public class ListRecordsByUserIdHandler : IRequestHandler<ListRecordsByUserIdQuery, ListRecordsByUserIdResponse>
    {
        private readonly IService<ListRecordsByUserIdResponse> _listService;

        public ListRecordsByUserIdHandler(IService<ListRecordsByUserIdResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListRecordsByUserIdResponse> Handle(ListRecordsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}