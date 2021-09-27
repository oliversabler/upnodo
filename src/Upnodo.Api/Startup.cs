using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Upnodo.Api.Installers.Extensions;
using Upnodo.Api.Middleware.Exceptions;

namespace Upnodo.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInstallersFromAssemblyContaining<IApiAssemblyMarker>(Configuration);

            services.AddHealthChecks();
            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            // Swagger documentation
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DisplayRequestDuration();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Upnodo Api v1");
            });

            // Custom Middleware for handling global exceptions
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = _ => false });
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions { Predicate = _ => false });
            });
        }
    }
}