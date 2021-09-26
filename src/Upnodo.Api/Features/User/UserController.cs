using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Features.User.Application.CreateUser;
using Upnodo.Features.User.Application.UpdateUser;

namespace Upnodo.Api.Features.User
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create", Name = nameof(CreateUser))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.CreateUserCommand(request), token);

            return Ok(result);
        }

        /// <summary>
        /// Use with caution, this request removes all previous saved user records.
        /// </summary>
        /// <remarks>Warning!</remarks>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("delete", Name = nameof(DeleteAllUsers))]
        public async Task<IActionResult> DeleteAllUsers(CancellationToken token)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteAllUsersCommand(), token);

            return NoContent();
        }

        [HttpDelete("{userId}", Name = nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(string userId, CancellationToken token)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteUserCommand(userId), token);

            return NoContent();
        }

        [HttpPut("update", Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.UpdateUserCommand(request), token);

            return Ok(result);
        }
    }
}