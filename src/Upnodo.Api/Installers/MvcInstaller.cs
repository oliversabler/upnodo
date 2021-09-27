using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;

namespace Upnodo.Api.Installers
{
    internal class MvcInstaller : IInstaller
    {
        public int Order { get; set; } = 0;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddControllers();
        }
    }
}
