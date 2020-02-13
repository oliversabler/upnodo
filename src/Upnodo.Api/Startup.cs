using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Upnodo.Api.Configurations;
using Upnodo.Infrastructure;
using Upnodo.Infrastructure.Repositories;

namespace Upnodo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(typeof(Startup));
            
            // Services
            services.AddRecords();

            // MongoDb
            services.Configure<DbSettings>(Configuration.GetSection(nameof(DbSettings)));
            services.AddSingleton<IDbSettings>(
                serviceProvider => serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value);
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}