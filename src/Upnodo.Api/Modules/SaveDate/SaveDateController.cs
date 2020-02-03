using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Domain.Commands;
using Upnodo.Domain.Requests;

namespace Upnodo.Api.Modules.SaveDate
{
    [Route("/api/save")]
    public class SaveDateController : Controller
    {
        private readonly IMediator _mediator;

        public SaveDateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveDateRequest request)
        {
            var response = 
                await _mediator.Send(new SaveDateCommand(request.Guid, request.Mode, request.Date));
            
            return Ok(response);
        }
    }
}