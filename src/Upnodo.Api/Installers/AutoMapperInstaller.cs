using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;
using Upnodo.Features.Mood.Application;
using Upnodo.Features.User.Application;

namespace Upnodo.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public int Order { get; set; } = 5;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(new[]
            {
                typeof(IMoodAssemblyMarker),
                typeof(IUserAssemblyMarker)
            });
        }
    }
}
