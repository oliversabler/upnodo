using System;
using System.Threading.Tasks;
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

        public Task<CreateUserResponse> RunAsync<T>(T request)
        {
            if (!(request is CreateUserCommand command))
            {
                throw new ArgumentException($"{nameof(request)} is not of type {typeof(CreateUserCommand)}");
            }

            var user = new Domain.User
            {
                Alias = command.Alias,
                Date = command.Date,
                Email = command.Email,
                Firstname = command.Firstname,
                UserId = command.UserId,
                Lastname = command.Lastname,
                MoodRecordGuids = command.MoodRecordGuids
            };

            var post = _userRepository.Create(user);
            
            return Task.FromResult(new CreateUserResponse(true, post));
        }
    }
}