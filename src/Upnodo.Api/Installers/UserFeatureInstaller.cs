using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upnodo.Api.Installers.Interfaces;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteAllUsers;
using Upnodo.Features.User.Application.DeleteUser;
using Upnodo.Features.User.Application.GetLatestCreatedUsers;
using Upnodo.Features.User.Application.GetUserByUserId;
using Upnodo.Features.User.Application.UpdateUser;
using Upnodo.Features.User.Infrastructure.Repositories;
using Upnodo.Features.User.Infrastructure.Services;

namespace Upnodo.Api.Installers
{
    public class UserFeatureInstaller : IInstaller
    {
        public int Order { get; set; } = 7;
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IService<CreateUserResponse>, CreateUserService>();
            services.AddTransient<IService<DeleteAllUsersResponse>, DeleteAllUsersService>();
            services.AddTransient<IService<DeleteUserResponse>, DeleteUserService>();
            services.AddTransient<IService<GetLatestCreatedUsersResponse>, GetLatestCreatedUsersService>();
            services.AddTransient<IService<GetUserByUserIdResponse>, GetUserByUserIdService>();
            services.AddTransient<IService<UpdateUserResponse>, UpdateUserService>();

            services.AddSingleton<MongoDbUserRepository>();
        }
    }
}
