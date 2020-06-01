using Microsoft.Extensions.DependencyInjection;
using Upnodo.Domain.Contracts;
using Upnodo.Modules.Records.Application;
using Upnodo.Modules.Records.Services;

namespace Upnodo.Api.Configurations
{
    internal static class RecordsStartup
    {
        internal static void AddRecords(this IServiceCollection s)
        {
            s.AddTransient<IService<SaveRecordResponse>, SaveRecordService>();
            s.AddTransient<IService<ListAllRecordsResponse>, ListAllRecordsService>();
            s.AddTransient<IService<ListRecordsByUserIdResponse>, ListRecordsByUserIdService>();
        }
    }
}