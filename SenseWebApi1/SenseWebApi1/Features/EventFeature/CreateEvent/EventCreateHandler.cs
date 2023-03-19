using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.CreateEvent
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, Guid>
    {
        private readonly IEventContext _eventContext;

        public EventCreateCommandHandler(IEventContext eventContext)
        {
            _eventContext = eventContext;

        }
        public async Task<Guid> Handle(EventCreateCommand command, CancellationToken cancellationToken)
        {
            Event @event = new Event();
            @event.EventId = Guid.NewGuid();
            @event.AreaId = command.AreaId;
            @event.ImageId = command.ImageId;
            @event.End = command.End;
            @event.Beginning = command.Beginning;
            @event.Description = command.Description;
            @event.EventName = command.EventName;
            await _eventContext.AddEvent(@event);
            return @event.EventId;
        }
    }
}
