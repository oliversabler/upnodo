using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Infrastructure;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Modules.Records.Services
{
    public class ListRecordsByUserIdService : IService<ListRecordsByUserIdResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public ListRecordsByUserIdService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<ListRecordsByUserIdResponse> RunAsync<T>(T request)
        {
            // Cast request and select userId
            if (!(request is ListRecordsByUserIdQuery requestAsJson))
            {
                throw new Exception("Bla bla bla");
            }
            
            var records = _tempDbContext.ListRecordsByUserId(requestAsJson.UserId);

            return Task.FromResult(new ListRecordsByUserIdResponse(true, records));
        }
    }
}