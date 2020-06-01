using Microsoft.Extensions.DependencyInjection;
using Upnodo.Domain.Contracts;
using Upnodo.Features.Mood.Application.SaveMood;
using Upnodo.Features.Mood.Infrastructure;
using Upnodo.Features.Mood.Infrastructure.Services;

namespace Upnodo.Api.Features.Mood.Configurations
{
    internal static class MoodStartup
    {
        internal static void AddMood(this IServiceCollection s)
        {
            s.AddTransient<IService<SaveMoodResponse>, SaveMoodService>();
            
            s.AddScoped<ITempDbContext, TempDbContext>();
        }
    }
}