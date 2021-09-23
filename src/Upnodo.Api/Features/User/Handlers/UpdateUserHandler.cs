using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.UpdateUser;

namespace Upnodo.Api.Features.User.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IService<UpdateUserResponse> _updateUserService;

        public UpdateUserHandler(IService<UpdateUserResponse> updateUserService)
        {
            _updateUserService = updateUserService;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken token)
        {
            return await _updateUserService.RunAsync(request, token);
        }
    }
}