using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Domain;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class CreateMoodRecordService : IService<CreateMoodRecordResponse>
    {
        private readonly MoodRecordRepository _moodRecordRepository;

        public CreateMoodRecordService(MoodRecordRepository moodRecordRepository)
        {
            _moodRecordRepository = moodRecordRepository;
        }

        public Task<CreateMoodRecordResponse> RunAsync<T>(T request)
        {
            if (request is not CreateMoodRecordCommand command)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateMoodRecordCommand)}");
            }

            var moodRecord = MoodRecord.CreateMood(
                command.DateCreated,
                command.MoodStatus,
                command.MoodRecordId,
                command.UserId,
                command.Username,
                command.Email);

            var response = _moodRecordRepository.Create(moodRecord);

            return Task.FromResult(new CreateMoodRecordResponse(true, response));
        }
    }
}