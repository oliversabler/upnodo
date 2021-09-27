using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Upnodo.Api.Filters;
using Upnodo.Api.Installers.Interfaces;

namespace Upnodo.Api.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public int Order { get; set; } = 2;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Upnodo Api", Version = "v1" });
                options.SchemaFilter<IgnoreReadOnlySchemaFilter>();

                var filePath = Path.Combine(AppContext.BaseDirectory, "Upnodo.Api.xml");
                options.IncludeXmlComments(filePath);
            });
        }
    }
}
