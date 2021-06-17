using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.DeleteUser;

namespace Upnodo.Api.Features.User.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IService<DeleteUserResponse> _deleteUserService;

        public DeleteUserHandler(IService<DeleteUserResponse> deleteUserService)
        {
            _deleteUserService = deleteUserService;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken token)
        {
            return await _deleteUserService.RunAsync(request, token);
        }
    }
}