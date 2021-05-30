using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Features.Mood.Configurations;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood
{
    [ApiController]
    [Route("api/mood/")]
    public class MoodController : Controller
    {
        private readonly IMediator _mediator;

        public MoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoodRecord([FromBody] CreateMoodRecordRequest request,
            CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.CreateMoodRecordCommand(request), token);

            return Ok(result);
        }

        [HttpDelete("{moodRecordId}")]
        public async Task<IActionResult> DeleteMoodRecord(string moodRecordId, CancellationToken token)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId), token);

            return NoContent();
        }

        [HttpGet("{moodRecordId}")]
        public async Task<IActionResult> GetMoodRecordsByMoodRecordId(string moodRecordId, CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.GetMoodRecordByMoodRecordIdQuery(moodRecordId), token);

            return Ok(result);
        }

        // Todo: Add (pagination)
        // [HttpGet("{userId}")]
        // public async Task<IActionResult> GetMoodRecordsByUserId(string userId)
        // {
        //     var result = await _mediator.Send(MediatorRequestFactory.GetMoodRecordsByUserIdQuery(userId));
        //
        //     return Ok(result);
        // }

        [HttpPut]
        public async Task<IActionResult> UpdateMoodRecord([FromBody] UpdateMoodRecordRequest request,
            CancellationToken token)
        {
            var result = await _mediator.Send(MediatorRequestFactory.UpdateMoodRecordCommand(request), token);

            return Ok(result);
        }
    }
}