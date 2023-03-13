using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.Events
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
            @event.AreaId = Guid.NewGuid();
            @event.ImageId = Guid.NewGuid();
            @event.End = command.End;
            @event.Beginning = command.Beginning;
            @event.Description = command.Description;
            @event.EventName = command.EventName;
            if (@event.Beginning > @event.End)
            {
                throw new Exception("начало позже окончания");
                
            }
            _eventContext.AddEvent(@event);
            return @event.EventId;
        }
    }
}
