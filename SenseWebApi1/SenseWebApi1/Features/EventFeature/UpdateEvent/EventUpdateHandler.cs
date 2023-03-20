using AutoMapper;
using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.UpdateEvent
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, EventUpdateDto>
    {
        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;
        private readonly IImageContext _imageContext;
        private readonly IAreaContext _areaContext;
        public EventUpdateCommandHandler(IEventContext eventContext, IMapper mapper, IImageContext imageContext, IAreaContext areaContext)
        {
            _eventContext = eventContext;
            _mapper = mapper;
            _imageContext = imageContext;
            _areaContext = areaContext;

        }
        public async Task<EventUpdateDto> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            var updateEvent = _mapper.Map<EventUpdateCommand, Event>(request);
            await _eventContext.UpdateEvent(updateEvent);
            var result = _mapper.Map<Event, EventUpdateDto>(updateEvent);
            return result;
        }
    }
}
