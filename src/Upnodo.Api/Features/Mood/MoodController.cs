using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Features.Mood.Configurations;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood
{
    [ApiController]
    public class MoodController : Controller
    {
        private readonly IMediator _mediator;

        public MoodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Route("/api/mood")]
        public async Task<IActionResult> SaveMood([FromBody]SaveMoodRequest saveMoodRequest)
        {
            var result = await _mediator.Send(MediatorRequestFactory.SaveMoodCommand(saveMoodRequest));

            return Ok(result);
        }
    }
}