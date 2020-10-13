using System;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteUser;

namespace Upnodo.Api.Features.User.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static CreateUserCommand CreateUserCommand(CreateUserRequest request)
        {
            return new CreateUserCommand(
                request.Alias,
                request.Email,
                request.Firstname,
                request.Lastname);
        }

        internal static DeleteUserCommand DeleteUserCommand(string userId)
        {
            return new DeleteUserCommand(userId);
        }
    }
}