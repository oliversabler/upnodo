using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Upnodo.Api.Configurations;
using Upnodo.Api.Features.Mood.Configurations;
using Upnodo.Api.Middleware.Exceptions;
using Upnodo.Infrastructure;

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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => 
                    options.JsonSerializerOptions.IgnoreNullValues = true);
            
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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Renault Api", Version = "v1"});
            });

            // MediatR
            services.AddMediatR(typeof(Startup));

            // Services
            services.AddRecords();
            services.AddMood();

            // MongoDb
            // services.Configure<DbSettings>(Configuration.GetSection(nameof(DbSettings)));
            // services.AddSingleton<IDbSettings>(
            //     serviceProvider => serviceProvider.GetRequiredService<IOptions<DbSettings>>().Value);

            // TempDb
            services.AddScoped<ITempDbContext, TempDbContext>();

            services.AddControllers();
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
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Renault Api v1"); });

            // Custom Middleware for handling global exceptions
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}