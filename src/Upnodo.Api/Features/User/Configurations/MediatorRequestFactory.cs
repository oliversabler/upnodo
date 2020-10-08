using Upnodo.Features.User.Application.CreateUser;

namespace Upnodo.Api.Features.User.Configurations
{
    internal static class MediatorRequestFactory
    {
        internal static CreateUserCommand CreateUserCommand(CreateUserRequest createUserRequest)
        {
            return new CreateUserCommand();
        }
    }
}