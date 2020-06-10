using Microsoft.Extensions.DependencyInjection;
using Upnodo.Features.Mood.Application.Contracts;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetAllMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordsByUserId;
using Upnodo.Features.Mood.Infrastructure;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MoodStartup
    {
        internal static void AddMood(this IServiceCollection s)
        {
            s.AddTransient<IService<CreateMoodRecordResponse>, CreateMoodRecordService>();
            s.AddTransient<IService<DeleteMoodRecordResponse>, DeleteMoodRecordService>();
            s.AddTransient<IService<GetAllMoodRecordsResponse>, GetAllMoodRecordsService>();
            s.AddTransient<IService<GetMoodRecordsByUserIdResponse>, GetMoodRecordsByUserId>();
            
            s.AddScoped<ITempDbContext, TempDbContext>();
        }
    }
}