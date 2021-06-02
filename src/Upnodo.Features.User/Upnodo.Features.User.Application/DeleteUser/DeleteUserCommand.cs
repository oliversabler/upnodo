using System;
using MediatR;

namespace Upnodo.Features.User.Application.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public string UserId { get; }

        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }
    }
}