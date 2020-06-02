using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.ListAllMoods;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class ListAllMoodsHandler : IRequestHandler<ListAllMoodsQuery, ListAllMoodsResponse>
    {
        private readonly IService<ListAllMoodsResponse> _listService;

        public ListAllMoodsHandler(IService<ListAllMoodsResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListAllMoodsResponse> Handle(ListAllMoodsQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}