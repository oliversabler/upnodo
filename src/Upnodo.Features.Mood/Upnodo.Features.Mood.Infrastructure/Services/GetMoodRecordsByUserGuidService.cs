using System;
using System.Threading.Tasks;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordsByUserGuidService : IService<GetMoodRecordsByUserGuidResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public GetMoodRecordsByUserGuidService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<GetMoodRecordsByUserGuidResponse> RunAsync<T>(T request)
        {
            if (!(request is GetMoodRecordsByUserGuidQuery query))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(GetMoodRecordsByUserGuidQuery)}");
            }
            
            var records = _tempDbContext.GetMoodRecordsByUserGuid(query.UserGuid);

            return Task.FromResult(new GetMoodRecordsByUserGuidResponse(true, records));
        }
    }
}