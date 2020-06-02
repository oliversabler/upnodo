using System;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class ListMoodsByUserIdService : IService<ListMoodsByUserIdResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public ListMoodsByUserIdService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<ListMoodsByUserIdResponse> RunAsync<T>(T request)
        {
            // Cast request and select userId
            if (!(request is ListMoodsByUserIdQuery requestAsJson))
            {
                throw new Exception("Bla bla bla");
            }
            
            var records = _tempDbContext.ListMoodsByUserId(requestAsJson.UserId);

            return Task.FromResult(new ListMoodsByUserIdResponse(true, records));
        }
    }
}