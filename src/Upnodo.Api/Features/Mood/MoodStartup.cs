using Microsoft.Extensions.DependencyInjection;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Repositories;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Features.Mood
{
    internal static class MoodStartup
    {
        internal static void AddMood(this IServiceCollection s)
        {
            s.AddTransient<IService<CreateMoodRecordResponse>, CreateMoodRecordService>();
            s.AddTransient<IService<DeleteAllMoodRecordsResponse>, DeleteAllMoodRecordsService>();
            s.AddTransient<IService<DeleteMoodRecordResponse>, DeleteMoodRecordService>();
            s.AddTransient<IService<GetMoodRecordByMoodRecordIdResponse>, GetMoodRecordByMoodRecordIdService>();
            s.AddTransient<IService<GetLatestCreatedMoodRecordsResponse>, GetLatestCreatedMoodRecordsService>();
            s.AddTransient<IService<UpdateMoodRecordResponse>, UpdateMoodRecordService>();

            s.AddSingleton<MongoDbRepository>();
        }
    }
}