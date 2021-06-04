using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MoodController> _logger;

        public MoodController(IMediator mediator, ILogger<MoodController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoodRecord([FromBody] CreateMoodRecordRequest request,
            CancellationToken token)
        {
            _logger.LogInformation($"{nameof(CreateMoodRecord)} request body: {JsonSerializer.Serialize(request)}");
            var result = await _mediator.Send(MediatorRequestFactory.CreateMoodRecordCommand(request), token);

            return Ok(result);
        }

        [HttpDelete("{moodRecordId}")]
        public async Task<IActionResult> DeleteMoodRecord(string moodRecordId, CancellationToken token)
        {
            _logger.LogInformation($"{nameof(DeleteMoodRecord)} moodRecordId: {moodRecordId}");
            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId), token);

            return NoContent();
        }

        [HttpGet("{moodRecordId}")]
        public async Task<IActionResult> GetMoodRecordsByMoodRecordId(string moodRecordId, CancellationToken token)
        {
            _logger.LogInformation($"{nameof(GetMoodRecordsByMoodRecordId)} moodRecordId: {moodRecordId}");
            var result = await _mediator.Send(MediatorRequestFactory.GetMoodRecordByMoodRecordIdQuery(moodRecordId),
                token);

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
            _logger.LogInformation($"{nameof(UpdateMoodRecord)} request body: {request}");
            var result = await _mediator.Send(MediatorRequestFactory.UpdateMoodRecordCommand(request), token);

            return Ok(result);
        }
    }
}