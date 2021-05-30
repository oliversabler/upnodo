using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class UpdateMoodRecordService : IService<UpdateMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        
        public UpdateMoodRecordService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<UpdateMoodRecordResponse> RunAsync<T>(T request)
        {
            if (request is not UpdateMoodRecordCommand command)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(UpdateMoodRecordCommand)}");
            }

            var moodRecord = MoodRecord.UpdateMood(
                command.DateUpdate,
                command.MoodStatus,
                command.MoodRecordId);
            
            var response = _moodRecordRepository.Update(moodRecord);

            return Task.FromResult(new UpdateMoodRecordResponse(true, response));
        }
    }
}