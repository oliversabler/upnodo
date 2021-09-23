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