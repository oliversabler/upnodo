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
    public class MoodController : Controller
    {
        private readonly IMediator _mediator;

        public MoodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("/api/mood/all")]
        public async Task<IActionResult> ListAllMoods([FromBody]ListAllMoodsRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListAllMoodsQuery(request));

            return Ok(result);
        }
        
        [HttpGet]
        [Route("/api/mood/byUserId")]
        public async Task<IActionResult> ListRecordsByUserId([FromBody]ListMoodsByUserIdRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListMoodsByUserIdQuery(request));

            return Ok(result);
        }
        
        [HttpPost]
        [Route("/api/mood/")]
        public async Task<IActionResult> SaveMood([FromBody]SaveMoodRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.SaveMoodCommand(request));

            return Ok(result);
        }
    }
}