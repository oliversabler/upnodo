using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;

namespace Upnodo.Api.Installers
{
    public class CorsInstaller : IInstaller
    {
        public int Order { get; set; } = 1;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader();
                    });
            });
        }
    }
}
