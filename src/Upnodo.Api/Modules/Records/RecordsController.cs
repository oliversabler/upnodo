using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Domain.Commands.Records;
using Upnodo.Domain.Queries.Records;
using Upnodo.Domain.Requests.Records;

namespace Upnodo.Api.Modules.Records
{
    [ApiController]
    public class RecordsController : Controller
    {
        private readonly IMediator _mediator;

        public RecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/records")]
        public async Task<IActionResult> Save([FromBody] SaveRequest request)
        {
            var result = 
                await _mediator.Send(new SaveCommand(request.Guid, request.Mode, request.Date));

            return Ok(result);
        }

        [HttpGet]
        [Route("/api/records")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var result =
                await _mediator.Send(new ListQuery());

            return Ok(result);
        }
    }
}