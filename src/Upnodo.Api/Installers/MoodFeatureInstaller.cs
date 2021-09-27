using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Repositories;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Installers
{
    public class MoodFeatureInstaller : IInstaller
    {
        public int Order { get; set; } = 6;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IService<CreateMoodRecordResponse>, CreateMoodRecordService>();
            services.AddTransient<IService<DeleteAllMoodRecordsResponse>, DeleteAllMoodRecordsService>();
            services.AddTransient<IService<DeleteMoodRecordResponse>, DeleteMoodRecordService>();
            services.AddTransient<IService<GetMoodRecordByMoodRecordIdResponse>, GetMoodRecordByMoodRecordIdService>();
            services.AddTransient<IService<GetLatestCreatedMoodRecordsResponse>, GetLatestCreatedMoodRecordsService>();
            services.AddTransient<IService<UpdateMoodRecordResponse>, UpdateMoodRecordService>();

            services.AddSingleton<MongoDbMoodRecordRepository>();
        }
    }
}
