using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upnodo.Api.Factories;
using Upnodo.Modules.Records.Application;

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
        
        [HttpGet]
        [Route("/api/records/")]
        public async Task<IActionResult> ListAllRecords([FromBody]ListAllRecordsRequest allRecordsRequest)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListAllRecordsQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("/api/records/")]
        public async Task<IActionResult> ListRecordsByUserId(string userId)
        {
            var result = await _mediator.Send(MediatorRequestFactory.ListRecordsByUserIdQuery(userId));

            return Ok(result);
        }
    }
}