using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.ImagesCommands;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers;
using SenseWebApi1.Stubs;
using System.Reflection.Metadata;
using System.Threading;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        

        public MainController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("events")]

        public async Task<IActionResult> CreateEvent(EventDto eventDto)
        {
            var eventCreateCommand = _mapper.Map<EventCreateCommand>(eventDto);
            var result=await _mediator.Send(eventCreateCommand);
            return Ok(result);
        }

        [HttpPut("events/{eventId}")]

        public async Task<IActionResult> ChangeEvent(EventDto eventDto)
        {
            var eventUpdateCommand = _mapper.Map<EventUpdateCommand>(eventDto);
            var result=await _mediator.Send(eventUpdateCommand);
            return Ok(result);
        }

        [HttpDelete("events/{eventId}")]

        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            _mediator.Send(new EventDeleteCommand() {EventId=eventId });
            return Ok();
        }

        [HttpGet("events")]

        public async Task<IActionResult> GetEvents()
        {
            
            
            var result =await _mediator.Send(new GetEventCommand());
            
            return Ok(result);
        }

        [HttpGet("image/{imageId}")]

        public async Task<IActionResult> CheckImage(Guid imageId)
        {
            var result = await _mediator.Send(new ImageCheckCommand() {ImageId=imageId });
            return Ok(result);
        }

        [HttpGet("image")]

        public async Task<IActionResult> GetImages()
        {
            var result=await _mediator.Send(new GetImagesCommand());
            return Ok(result);
        }
        [HttpGet("area/{areaId}")]

        public async Task<IActionResult> CheckArea(Guid areaId)
        {
            var result = await _mediator.Send(new AreaCheckCommand() { AreaId = areaId });
            return Ok(result);
        }

        [HttpGet("area")]

        public async Task<IActionResult> GetAreas()
        {
            var result = await _mediator.Send(new GetAreasCommand());
            return Ok(result);
        }

    }
}
