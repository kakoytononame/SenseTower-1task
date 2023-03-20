using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.DeleteEvent
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
            await _eventContext.RemoveEvent(request.EventId);
            return request.EventId;
        }
    }
}
