using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Upnodo.Api.Installers.Interfaces;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Settings;

namespace Upnodo.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public int Order { get; set; } = 4;

        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(
                configuration.GetSection(nameof(MongoDbSettings)));

            services.AddSingleton<IMongoDbSettings>(sp =>
            {
                var val = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                if (string.IsNullOrEmpty(val.ConnectionString) ||
                    string.IsNullOrEmpty(val.DatabaseName) ||
                    string.IsNullOrEmpty(val.MoodsCollectionName) ||
                    string.IsNullOrEmpty(val.UsersCollectionName))
                {
                    throw new Exception($"Missing values in {nameof(MongoDbSettings)}, " +
                        "check if your appsettings.json settings are aligned with the class name.");
                }

                return val;
            });
        }
    }
}
