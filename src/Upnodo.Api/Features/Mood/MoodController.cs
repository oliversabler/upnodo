using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upnodo.Features.Mood.Application.CreateMoodRecord;
using Upnodo.Features.Mood.Application.GetMoodRecordByRecordId;
using Upnodo.Features.Mood.Application.UpdateMoodRecord;

namespace Upnodo.Api.Features.Mood
{
    [ApiController]
    [Produces("application/json")]
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

        [HttpPost("create", Name = nameof(CreateMoodRecord))]
        public async Task<IActionResult> CreateMoodRecord(
            [FromBody] CreateMoodRecordRequest request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(CreateMoodRecord)} request body: {JsonSerializer.Serialize(request)}");

            var result = await _mediator.Send(MediatorRequestFactory.CreateMoodRecordCommand(request), token);

            return Ok(result);
        }

        /// <summary>
        /// Use with caution, this request removes all previous saved mood records.
        /// </summary>
        /// <remarks>Warning!</remarks>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("delete", Name = nameof(DeleteAllMoodRecords))]
        public async Task<IActionResult> DeleteAllMoodRecords(CancellationToken token)
        {
            _logger.LogTrace(nameof(DeleteAllMoodRecords));

            await _mediator.Send(MediatorRequestFactory.DeleteAllMoodRecordsCommand(), token);

            return NoContent();
        }

        [HttpDelete("delete/{moodRecordId}", Name = nameof(DeleteMoodRecord))]
        public async Task<IActionResult> DeleteMoodRecord(string moodRecordId, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteMoodRecord)} moodRecordId: {moodRecordId}");

            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId), token);

            return NoContent();
        }

        [HttpGet("read/{numberOfMoodRecords:int}", Name = nameof(GetLatestCreatedMoodRecords))]
        public async Task<IActionResult> GetLatestCreatedMoodRecords(int numberOfMoodRecords, CancellationToken token)
        {
            _logger.LogTrace(
                $"{nameof(GetLatestCreatedMoodRecords)} numberOfMoodRecords: {numberOfMoodRecords.ToString()}");

            var result = await _mediator.Send(
                MediatorRequestFactory.GetLatestCreatedMoodRecordsQuery(numberOfMoodRecords),
                token);

            return Ok(result);
        }

        [HttpPost("read", Name = nameof(GetMoodRecordsByMoodRecordId))]
        public async Task<IActionResult> GetMoodRecordsByMoodRecordId(
            [FromBody] GetMoodRecordByMoodRecordIdRequest request,
            CancellationToken token)
        {
            _logger.LogTrace(
                $"{nameof(GetMoodRecordsByMoodRecordId)} request body: {JsonSerializer.Serialize(request)}");

            var result = await _mediator.Send(
                MediatorRequestFactory.GetMoodRecordByMoodRecordIdQuery(request),
                token);

            return Ok(result);
        }

        [HttpPut("update", Name = nameof(UpdateMoodRecord))]
        public async Task<IActionResult> UpdateMoodRecord(
            [FromBody] UpdateMoodRecordRequest request,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(UpdateMoodRecord)} request body: {request}");

            var result = await _mediator.Send(MediatorRequestFactory.UpdateMoodRecordCommand(request), token);

            return Ok(result);
        }
    }
}