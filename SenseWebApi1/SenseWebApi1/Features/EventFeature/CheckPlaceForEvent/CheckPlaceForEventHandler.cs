using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.EventFeature.CheckPlaceForEvent
{
    public class CheckPlaceForEventHandler : IRequestHandler<CheckPlaceForEventCommand, bool>
    {
        private readonly IEventContext _eventContext;
        public CheckPlaceForEventHandler(IEventContext eventContext) 
        {
            _eventContext = eventContext;
        }
        public Task<bool> Handle(CheckPlaceForEventCommand request, CancellationToken cancellationToken)
        {
            return _eventContext.CheckPlaceForEvent(request.eventId, request.place);
        }
    }
}
