using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Features.Mood.Configurations;
using Upnodo.Features.Mood.Application.ListAllMoods;
using Upnodo.Features.Mood.Application.ListMoodsByUserId;
using Upnodo.Features.Mood.Application.SaveMood;

namespace Upnodo.Api.Features.Mood
{
    [ApiController]
    [Route("api/mood/[controller]")]
    public class MoodController : Controller
    {
        private readonly IMediator _mediator;

        public MoodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // Todo: Fix endpoint and change name of model
        [HttpGet]
        public async Task<IActionResult> ListAllMoods()
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListAllMoodsQuery());

            return Ok(result);
        }
        
        // Todo: Fix endpoint and change name of model
        //       Post or Get?
        [HttpGet("{userId}")]
        public async Task<IActionResult> ListMoodsByUserId(string userId)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListMoodsByUserIdQuery(userId));

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveMood([FromBody]SaveMoodRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.SaveMoodCommand(request));

            return Ok(result);
        }
    }
}