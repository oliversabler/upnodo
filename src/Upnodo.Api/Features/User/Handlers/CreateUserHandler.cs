using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;

namespace Upnodo.Api.Features.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IService<CreateUserResponse> _createUserService;

        public CreateUserHandler(IService<CreateUserResponse> createUserService)
        {
            _createUserService = createUserService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken token)
        {
            return await _createUserService.RunAsync(request, token);
        }
    }
}