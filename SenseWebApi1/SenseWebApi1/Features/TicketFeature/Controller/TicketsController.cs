using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.TicketsCommand;
using SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Controller
{
    [ApiController]
    [Route("api")]
    public class TicketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TicketsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("tickets")]
        public async Task<IActionResult> AddFreeTickets(Guid EventId, int countoftickets)
        {

            var result = await _mediator.Send(new AddFreeTicketsCommand() {EventId=EventId, countoftickets = countoftickets });
            return Ok(result);
        }

        [HttpPut("tickets/{ticketId}")]

        public async Task<IActionResult> GiveTicketForUser(Guid ticketId,Guid OwnerId)
        {
            var result = await _mediator.Send(new GiveTicketForUserCommand() { TicketId = ticketId, OwnerId = OwnerId });
            return Ok(result);
        }
    }
}
