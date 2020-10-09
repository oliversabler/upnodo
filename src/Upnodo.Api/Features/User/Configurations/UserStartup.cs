using Microsoft.Extensions.DependencyInjection;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Infrastructure.Services;

namespace Upnodo.Api.Features.User.Configurations
{
    internal static class UserStartup
    {
        internal static void AddUser(this IServiceCollection s)
        {
            s.AddSingleton<UserService>();

            s.AddTransient<IService<CreateUserResponse>, CreateUserService>();
        }
    }
}