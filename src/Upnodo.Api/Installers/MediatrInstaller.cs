using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;
using Upnodo.Api.PipelineBehaviors;
using Upnodo.Features.Mood.Application;
using Upnodo.Features.User.Application;

namespace Upnodo.Api.Installers
{
    public class MediatrInstaller : IInstaller
    {
        public int Order { get; set; } = 3;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(new[]
            {
                typeof(IMoodAssemblyMarker),
                typeof(IUserAssemblyMarker)
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));
        }
    }
}
