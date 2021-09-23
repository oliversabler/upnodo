using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class CreateUserService : IService<CreateUserResponse>
    {
        private readonly UserRepository _userRepository;

        public CreateUserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<CreateUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not CreateUserCommand command)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateUserCommand)}");
            }

            var user = new Domain.User(
                command.Alias,
                command.Date,
                command.Email,
                command.Firstname,
                command.UserId,
                command.Lastname);

            var response = _userRepository.Create(user);

            return Task.FromResult(new CreateUserResponse(true, response));
        }
    }
}