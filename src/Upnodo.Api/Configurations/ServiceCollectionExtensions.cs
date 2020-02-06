using Microsoft.Extensions.DependencyInjection;
using Upnodo.Domain.Contracts;
using Upnodo.Domain.Responses.Records;
using Upnodo.Infrastructure.Services.Records;

namespace Upnodo.Api.Configurations
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddRecordsDi(this IServiceCollection s)
        {
            s.AddTransient<IService<SaveResponse>, SaveService>();
            s.AddTransient<IService<ListResponse>, ListService>();
        }
    }
}