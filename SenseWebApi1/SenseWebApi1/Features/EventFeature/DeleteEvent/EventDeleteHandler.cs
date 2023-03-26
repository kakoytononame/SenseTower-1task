using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.RMQ;

namespace SenseWebApi1.Features.EventFeature.DeleteEvent
{
    public class EventDeleteCommandHandler : IRequestHandler<EventDeleteCommand, Guid>
    {
        private readonly IEventContext _eventContext;
        private readonly IRmqSender _rmqSender;
        public EventDeleteCommandHandler(IEventContext eventContext,IRmqSender rmqSender)
        {
            _eventContext = eventContext;
            _rmqSender = rmqSender;
        }
        public async Task<Guid> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            await _eventContext.RemoveEvent(request.EventId);
            await _rmqSender.SendDeleteEvent(request.EventId);
            return request.EventId;
        }
    }
}
