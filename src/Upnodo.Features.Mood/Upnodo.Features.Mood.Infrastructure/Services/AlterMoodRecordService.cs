using System;
using System.Threading.Tasks;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Application.Contracts;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class AlterMoodRecordService : IService<AlterMoodRecordResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public AlterMoodRecordService(ITempDbContext tempDbContext)
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