using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class AlterMoodRecordService : IService<AlterMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;
        
        public AlterMoodRecordService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<AlterMoodRecordResponse> RunAsync<T>(T request)
        {
            if (!(request is AlterMoodRecordCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(AlterMoodRecordCommand)}");
            }

            var user = new MoodRecord(
                command.DateUpdate,
                command.Mood,
                command.MoodRecordId);
            
            var response = _moodRecordRepository.Alter(user);

            return Task.FromResult(new AlterMoodRecordResponse(true, response));
        }
    }
}