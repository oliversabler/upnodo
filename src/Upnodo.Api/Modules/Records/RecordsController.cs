using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Factories;
using Upnodo.Modules.Records.Application;

namespace Upnodo.Api.Modules.Records
{
    [ApiController]
    [Route("/api/records")]
    public class RecordsController : Controller
    {
        private readonly IMediator _mediator;

        public RecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]SaveRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.SaveCommand(request));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromBody]ListRequest request)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListQuery(request));

            return Ok(result);
        }
    }
}