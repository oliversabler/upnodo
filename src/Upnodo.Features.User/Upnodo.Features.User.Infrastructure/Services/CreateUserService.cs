using System;
using System.Threading.Tasks;
using Upnodo.BuildingBlocks.Application.Contracts;
using Upnodo.Features.User.Application.CreateUser;

namespace Upnodo.Features.User.Infrastructure.Services
{
    public class CreateUserService : IService<CreateUserResponse>
    {
        private readonly UserService _userService;

        public CreateUserService(UserService userService)
        {
            _userService = userService;
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
                Guid = command.Guid,
                Lastname = command.Lastname,
                MoodRecordGuids = command.MoodRecordGuids
            };

            var post = _userService.Create(user);
            
            return Task.FromResult(new CreateUserResponse(true, post));
        }
    }
}