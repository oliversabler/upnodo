using Microsoft.Extensions.DependencyInjection;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserGuid;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Infrastructure;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MoodStartup
    {
        internal static void AddMood(this IServiceCollection s)
        {
            s.AddTransient<IService<UpdateMoodRecordResponse>, UpdateMoodRecordService>();
            s.AddTransient<IService<CreateMoodRecordResponse>, CreateMoodRecordService>();
            s.AddTransient<IService<DeleteMoodRecordResponse>, DeleteMoodRecordService>();
            s.AddTransient<IService<GetMoodRecordsByUserGuidResponse>, GetMoodRecordsByUserGuidService>();

            s.AddSingleton<MoodRecordRepository>();
        }
    }
}