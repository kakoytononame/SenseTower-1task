using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.EventFeature.EventsCommands;

namespace SenseWebApi1.Features.EventFeature.EventsHandlers
{
    public class EventCreateCommandHandler : IRequestHandler<EventCreateCommand, Guid>
    {
        private readonly IEventContext _eventContext;
        private readonly IImageContext _imageContext;
        private readonly IAreaContext _areaContext;
        public EventCreateCommandHandler(IEventContext eventContext, IImageContext imageContext, IAreaContext areaContext)
        {
            _eventContext = eventContext;
            _imageContext = imageContext;
            _areaContext = areaContext;

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
