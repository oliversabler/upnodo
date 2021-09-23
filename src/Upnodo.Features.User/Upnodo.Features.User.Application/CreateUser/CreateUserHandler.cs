using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Upnodo.BuildingBlocks.Application.Abstractions;

namespace Upnodo.Features.User.Application.CreateUser
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