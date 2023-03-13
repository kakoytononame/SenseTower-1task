using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController
{
    [ApiController]
    [Route("api")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("events")]

        public async Task<IActionResult> CreateEvent()
        {
            return Ok();
        }

        [HttpPut("events/{eventId}")]

        public async Task<IActionResult> ChangeEvent()
        {
            return Ok();
        }

        [HttpDelete("events/{eventId}")]

        public async Task<IActionResult> DeleteEvent()
        {
            return Ok();
        }

        [HttpGet("events")]

        public async Task<IActionResult> GetEvents()
        {
            return Ok();
        }
    }
}
