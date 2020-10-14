using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class DeleteMoodRecordService : IService<DeleteMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public DeleteMoodRecordService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<DeleteMoodRecordResponse> RunAsync<T>(T request)
        {
            if (!(request is DeleteMoodRecordCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteMoodRecordCommand)}");
            }
            
            _moodRecordRepository.Delete(command.MoodId);

            return Task.FromResult(new DeleteMoodRecordResponse());
        }
    }
}