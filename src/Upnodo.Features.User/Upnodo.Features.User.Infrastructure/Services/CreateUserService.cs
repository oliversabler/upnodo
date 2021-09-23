using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Infrastructure.Mappers;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class CreateUserService : IService<CreateUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;

        public CreateUserService(MongoDbUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not Domain.User user)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateUserCommand)}");
            }

            var response = await _userRepository.CreateAsync(UserMapper.GetDto(user));

            return new CreateUserResponse(true, response);
        }
    }
}