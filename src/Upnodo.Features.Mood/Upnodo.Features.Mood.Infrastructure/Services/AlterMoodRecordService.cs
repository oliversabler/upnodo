using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.AlterMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class AlterMoodRecordService : IService<AlterMoodRecordResponse>
    {
        private readonly IDbContext _tempDbContext;

        public AlterMoodRecordService(IDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<AlterMoodRecordResponse> RunAsync<T>(T request)
        {
            if (!(request is AlterMoodRecordCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(AlterMoodRecordCommand)}");
            }
            
            var response = _tempDbContext.AlterMoodRecord(command);

            return Task.FromResult(new AlterMoodRecordResponse(true, response));
        }
    }
}