using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteAllUsers;
using Upnodo.Features.User.Application.DeleteUser;
using Upnodo.Features.User.Application.UpdateUser;

namespace Upnodo.Api.Features.User
{
    internal static class MediatorRequestFactory
    {
        internal static CreateUserCommand CreateUserCommand(CreateUserRequest request)
        {
            return new CreateUserCommand(
                request.Username,
                request.Email,
                request.Firstname,
                request.Lastname);
        }

        internal static DeleteAllUsersCommand DeleteAllUsersCommand()
        {
            return new();
        }

        internal static DeleteUserCommand DeleteUserCommand(string userId)
        {
            return new DeleteUserCommand(userId);
        }

        public static UpdateUserCommand UpdateUserCommand(UpdateUserRequest request)
        {
            return new UpdateUserCommand(
                request.Username,
                request.Email,
                request.Firstname,
                request.Lastname,
                request.UserId);
        }
    }
}