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

        [HttpPost]
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
        [HttpDelete("delete", Name = nameof(DeleteAllMoodRecords))]
        public async Task<IActionResult> DeleteAllMoodRecords(CancellationToken token)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteAllUsersCommand(), token);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId, CancellationToken token)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteUserCommand(userId), token);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.UpdateUserCommand(request), token);

            return Ok(result);
        }
    }
}