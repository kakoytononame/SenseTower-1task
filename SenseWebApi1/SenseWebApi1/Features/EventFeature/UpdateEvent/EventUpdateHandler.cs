using AutoMapper;
using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.UpdateEvent
{
    // ReSharper disable once UnusedType.Global
    public class EventUpdateHandler : IRequestHandler<EventUpdateCommand, EventUpdateDto>
    {
        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;

        public EventUpdateHandler(IEventContext eventContext, IMapper mapper)
        {
            _eventContext = eventContext;
            _mapper = mapper;


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
