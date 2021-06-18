using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Domain;
using Upnodo.Features.Mood.Infrastructure.DTO;
using Upnodo.Features.Mood.Infrastructure.Repositories;

namespace Upnodo.Features.Mood.Infrastructure.Services
{
    public class CreateMoodRecordService : IService<CreateMoodRecordResponse>
    {
        private readonly MongoDbRepository _mongoDbRepository;
        private readonly ILogger<CreateMoodRecordService> _logger;

        public CreateMoodRecordService(
            MongoDbRepository mongoDbRepository,
            ILogger<CreateMoodRecordService> logger)
        {
            _mongoDbRepository = mongoDbRepository;
            _logger = logger;
        }

        public async Task<CreateMoodRecordResponse> RunAsync<T>(T request, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(RunAsync)} in {nameof(CreateMoodRecordService)} running.");

            if (request is not MoodRecord moodRecord)
            {
                _logger.LogError(
                    $"{nameof(request)} with body: {JsonSerializer.Serialize(request)} " +
                    $"is not of type {typeof(CreateMoodRecordCommand)}");

                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateMoodRecordCommand)}");
            }
            
            // Todo: Automapper
            var dto = new MoodRecordDto
            {
                MoodRecordId = moodRecord.MoodRecordId,
                DateCreated = moodRecord.DateCreated,
                MoodStatus = moodRecord.MoodStatus,
                User = new UserDto
                {
                    UserId = moodRecord.User!.UserId!,
                    Username = moodRecord.User!.Username!,
                    Email = moodRecord.User!.Email!,
                    Firstname = moodRecord.User.Firstname,
                    Lastname = moodRecord.User.Lastname,
                    Fullname = moodRecord.User.Fullname
                }
            };

            var response = await _mongoDbRepository.CreateAsync(dto);

            return new CreateMoodRecordResponse(true, response);
        }
    }
}