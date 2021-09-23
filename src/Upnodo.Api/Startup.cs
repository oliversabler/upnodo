using System;
using System.IO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Upnodo.Api.Features.Mood;
using Upnodo.Api.Features.User;
using Upnodo.Api.Filters;
using Upnodo.Api.Middleware.Exceptions;
using Upnodo.Api.PipelineBehaviors;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Settings;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.DeleteAllMoodRecords;
using Upnodo.Features.Mood.Application.DeleteMoodRecord;
using Upnodo.Features.Mood.Application.GetLatestCreatedMoodRecords;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;
using Upnodo.Features.Mood.Infrastructure.Mappers;
using Upnodo.Features.Mood.Infrastructure.Services;

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
            services.AddHealthChecks();

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

            services.AddMemoryCache();

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Upnodo Api", Version = "v1" });
                options.SchemaFilter<IgnoreReadOnlySchemaFilter>();

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Upnodo.Api.xml");
                options.IncludeXmlComments(filePath);
            });

            // MediatR
            RegisterMediatr(services);

            // MongoDb
            RegisterMongoDb(services);

            // AutoMapper
            services.AddAutoMapper(new[] { typeof(MoodRecordMapper) });

            // Services
            services.AddMood();
            services.AddUser();

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

        private void RegisterMediatr(IServiceCollection services)
        {
            services.AddMediatR(new[]
            {
                typeof(CreateMoodRecordHandler),
                typeof(DeleteAllMoodRecordsHandler),
                typeof(DeleteMoodRecordHandler),
                typeof(GetLatestCreatedMoodRecordsHandler),
                typeof(GetMoodRecordByMoodRecordIdHandler),
                typeof(UpdateMoodRecordHandler)
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));
        }

        private void RegisterMongoDb(IServiceCollection services)
        {
            services.Configure<MongoDbSettings>(
                Configuration.GetSection(nameof(MongoDbSettings)));

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