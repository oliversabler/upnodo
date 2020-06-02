using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;

namespace Upnodo.Api.Features.Mood.Handlers
{
    public class ListMoodsByUserIdHandler : IRequestHandler<ListMoodsByUserIdQuery, ListMoodsByUserIdResponse>
    {
        private readonly IService<ListMoodsByUserIdResponse> _listService;

        public ListMoodsByUserIdHandler(IService<ListMoodsByUserIdResponse> listService)
        {
            _listService = listService;
        }

        public async Task<ListMoodsByUserIdResponse> Handle(ListMoodsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _listService.RunAsync(request);
        }
    }
}