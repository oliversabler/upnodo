using System;
using System.Threading.Tasks;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteMoodRecordService : IService<DeleteMoodRecordResponse>
    {
        private readonly ITempDbContext _tempDbContext;

        public DeleteMoodRecordService(ITempDbContext tempDbContext)
        {
            _tempDbContext = tempDbContext;
        }

        public Task<DeleteMoodRecordResponse> RunAsync<T>(T request)
        {
            if (!(request is DeleteMoodRecordCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteMoodRecordCommand)}");
            }
            
            _tempDbContext.DeleteMoodRecord(command.Guid);

            // Todo: No need for DeleteMoodRecordResponse to return with true.
            return Task.FromResult(new DeleteMoodRecordResponse(true));
        }
    }
}