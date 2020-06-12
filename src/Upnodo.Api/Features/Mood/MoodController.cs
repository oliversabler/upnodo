using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Features.Mood.Configurations;
using Upnodo.Features.Mood.Application.AlterMoodRecord;
using Upnodo.Features.Mood.Application.CreateMoodRecord;

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
        
        [HttpPut]
        public async Task<IActionResult> AlterMoodRecord([FromBody]AlterMoodRecordRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.AlterMoodRecordCommand(request));
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMoodRecord([FromBody]CreateMoodRecordRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.CreateMoodRecordCommand(request));

            return Ok(result);
        }
        
        [HttpDelete("{moodRecordId}")]
        public async Task<IActionResult> DeleteMoodRecord(Guid moodRecordId)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId));

            return NoContent();
        }

        // Todo: Only admin should be able to fetch all registered mood records
        [HttpGet]
        public async Task<IActionResult> GetAllMoodRecords()
        {
            var result = await _mediator.Send(MediatorRequestFactory.GetAllMoodRecordsQuery());

            return Ok(result);
        }
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMoodRecordsByUserId(string userId)
        {
            var result = await _mediator.Send(MediatorRequestFactory.GetMoodRecordsByUserIdQuery(userId));

            return Ok(result);
        }
    }
}