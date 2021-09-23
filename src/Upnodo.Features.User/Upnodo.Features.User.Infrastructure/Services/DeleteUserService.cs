using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteUser;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class DeleteUserService : IService<DeleteUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;

        public DeleteUserService(MongoDbUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<DeleteUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not DeleteUserCommand command)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteUserCommand)}");
            }

            _userRepository.Delete(command.UserId);

            return Task.FromResult(new DeleteUserResponse(true, null));
        }
    }
}