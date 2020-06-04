using System;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserId;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class GetMoodRecordsByUserId : IService<GetMoodRecordsByUserIdResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public GetMoodRecordsByUserId(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<GetMoodRecordsByUserIdResponse> RunAsync<T>(T request)
        {
            if (!(request is GetMoodRecordsByUserIdQuery query))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(GetMoodRecordsByUserIdQuery)}");
            }
            
            var records = _tempDbContext.GetMoodRecordsByUserId(query.UserId);

            return Task.FromResult(new GetMoodRecordsByUserIdResponse(true, records));
        }
    }
}