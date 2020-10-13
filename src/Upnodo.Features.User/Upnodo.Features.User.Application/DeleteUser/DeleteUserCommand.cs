using System;
using MediatR;

namespace Upnodo.Features.User.Application.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}