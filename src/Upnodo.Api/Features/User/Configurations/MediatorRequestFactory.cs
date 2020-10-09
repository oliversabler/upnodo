using Upnodo.Features.User.Application.CreateUser;

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
    }
}