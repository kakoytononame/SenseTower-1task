using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.Events
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, EventDto>
    {
        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;
        public EventUpdateCommandHandler(IEventContext eventContext, IMapper mapper)
        {
            _eventContext = eventContext;
            _mapper = mapper;
        }
        public async Task<EventDto> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            Event updateevent = _mapper.Map<EventUpdateCommand, Event>(request);
            _eventContext.UpdateEvent(updateevent);
            EventDto result = _mapper.Map<Event, EventDto>(updateevent);
            return result;
        }
    }
}
