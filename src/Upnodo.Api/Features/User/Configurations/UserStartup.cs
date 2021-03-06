using Microsoft.Extensions.DependencyInjection;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteUser;
using Upnodo.Features.User.Application.UpdateUser;
using Upnodo.Features.User.Infrastructure;
using Upnodo.Features.User.Infrastructure.Services;

namespace Upnodo.Api.Features.User.Configurations
{
    internal static class UserStartup
    {
        internal static void AddUser(this IServiceCollection s)
        {
            s.AddTransient<IService<CreateUserResponse>, CreateUserService>();
            s.AddTransient<IService<DeleteUserResponse>, DeleteUserService>();
            s.AddTransient<IService<UpdateUserResponse>, UpdateUserService>();

            s.AddSingleton<UserRepository>();
        }
    }
}