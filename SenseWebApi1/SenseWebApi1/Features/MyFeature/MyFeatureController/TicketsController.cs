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
        public async Task<IActionResult> AddFreeTickets(TicketDto ticketDto,int countoftickets)
        {
            
            var result = await _mediator.Send(new AddFreeTicketsCommand() {AreaId=ticketDto.AreaId,countoftickets=countoftickets });
            return Ok(result);
        }
    }
}
