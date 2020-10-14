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
            if (!(request is UpdateMoodRecordCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(UpdateMoodRecordCommand)}");
            }

            var user = new MoodRecord(
                command.DateUpdate,
                command.Mood,
                command.MoodRecordId);
            
            var response = _moodRecordRepository.Update(user);

            return Task.FromResult(new UpdateMoodRecordResponse(true, response));
        }
    }
}