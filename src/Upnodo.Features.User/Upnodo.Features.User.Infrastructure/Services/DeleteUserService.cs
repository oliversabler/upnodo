using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.DeleteUser;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class DeleteUserService : IService<DeleteUserResponse>
    {
        private readonly UserRepository _userRepository;

        public DeleteUserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<DeleteUserResponse> RunAsync<T>(T request)
        {
            if (!(request is DeleteUserCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(DeleteUserCommand)}");
            }
            
            _userRepository.Delete(command.UserId);
            
            return Task.FromResult(new DeleteUserResponse(true, null));
        }
    }
}