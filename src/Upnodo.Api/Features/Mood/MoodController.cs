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
        
        [HttpPut]
        public async Task<IActionResult> UpdateMoodRecord([FromBody]UpdateMoodRecordRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.UpdateMoodRecordCommand(request));
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMoodRecord([FromBody]CreateMoodRecordRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.CreateMoodRecordCommand(request));

            return Ok(result);
        }
        
        [HttpDelete("{moodRecordId}")]
        public async Task<IActionResult> DeleteMoodRecord(string moodRecordId)
        {
            await _mediator.Send(MediatorRequestFactory.DeleteMoodRecordCommand(moodRecordId));

            return NoContent();
        }

        // Todo: Add (pagination)
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMoodRecordsByUserGuid(string userId)
        {
            var result = await _mediator.Send(MediatorRequestFactory.GetMoodRecordsByUserGuidQuery(userId));

            return Ok(result);
        }
    }
}