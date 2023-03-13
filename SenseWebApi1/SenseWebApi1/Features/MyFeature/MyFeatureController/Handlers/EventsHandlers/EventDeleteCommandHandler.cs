using MediatR;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.Events
{
    public class EventDeleteCommandHandler : IRequestHandler<EventDeleteCommand, Guid>
    {
        private readonly IEventContext _eventContext;
        public EventDeleteCommandHandler(IEventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public async Task<Guid> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            _eventContext.RemoveEvent(request.EventId);
            return request.EventId;
        }
    }
}
