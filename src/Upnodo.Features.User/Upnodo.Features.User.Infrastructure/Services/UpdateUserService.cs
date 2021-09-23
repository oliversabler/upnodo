using System;
using System.Threading;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Abstractions;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.UpdateUser;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class UpdateUserService : IService<UpdateUserResponse>
    {
        private readonly MongoDbUserRepository _userRepository;

        public UpdateUserService(MongoDbUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UpdateUserResponse> RunAsync<T>(T request, CancellationToken token)
        {
            if (request is not UpdateUserCommand command)
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(UpdateUserCommand)}");
            }

            //var user = new Domain.User(
            //    command.Alias,
            //    command.DateUpdated,
            //    command.Email,
            //    command.Firstname,
            //    command.Lastname);

            var response = _userRepository.Update(command.UserId, null);

            return Task.FromResult(new UpdateUserResponse(true, response));
        }
    }
}