using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.TicketsCommand;
using SenseWebApi1.Features.MyFeature.Handlers.TicketsHandlers;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController
{
    [ApiController]
    [Route("api")]
    public class TicketsController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TicketsController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("tickets")]
        
        private async Task<IActionResult> AddFreeTickets(TicketDto ticketDto)
        {
            var ticketcommand = _mapper.Map<AddFreeTicketsCommand>(ticketDto);
            var result = await _mediator.Send(ticketcommand);
            return Ok(result);
        }
    }
}
