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
        [HttpDelete]
        public async Task<IActionResult> DeleteAllMoodRecords(CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteAllMoodRecords)}");
            await _mediator.Send(MediatorRequestFactory.DeleteAllMoodRecordsCommand(), token);

            return NoContent();
        }

        [HttpDelete("{moodRecordId}")]
        public async Task<IActionResult> DeleteMoodRecord(string moodRecordId, CancellationToken token)
        {
            _logger.LogTrace($"{nameof(DeleteMoodRecord)} moodRecordId: {moodRecordId}");
            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId), token);

            return NoContent();
        }

        [HttpGet("{moodRecordId}, {bypassCache:bool}")]
        public async Task<IActionResult> GetMoodRecordsByMoodRecordId(
            string moodRecordId, 
            bool bypassCache,
            CancellationToken token)
        {
            _logger.LogTrace($"{nameof(GetMoodRecordsByMoodRecordId)} moodRecordId: {moodRecordId}");
            var result = await _mediator.Send(
                MediatorRequestFactory.GetMoodRecordByMoodRecordIdQuery(moodRecordId, bypassCache),
                token);

            return Ok(result);
        }

        [HttpGet("{numberOfMoodRecords:int}")]
        public async Task<IActionResult> GetLatestCreatedMoodRecords(int numberOfMoodRecords, CancellationToken token)
        {
            _logger.LogTrace(
                $"{nameof(GetLatestCreatedMoodRecords)} numberOfMoodRecords: {numberOfMoodRecords.ToString()}");
            
            var result = await _mediator.Send(
                MediatorRequestFactory.GetLatestCreatedMoodRecordsQuery(numberOfMoodRecords),
                token);

            return Ok(result);
        }

        [HttpPut]
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