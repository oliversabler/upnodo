using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.ListAllMoods;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class ListAllMoodsService : IService<ListAllMoodsResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public ListAllMoodsService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<ListAllMoodsResponse> RunAsync<T>(T request)
        {
            var records = _tempDbContext.ListAllMoods();

            return Task.FromResult(new ListAllMoodsResponse(true, records));
        }
    }
}