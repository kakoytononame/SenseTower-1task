using AutoMapper;
using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature;

namespace SenseWebApi1.Features.EventFeature.GetEvents
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand, IEnumerable<EventDto>>
    {

        private readonly IEventContext _eventContext;
        private readonly IMapper _mapper;
        private readonly ITicketContext _ticketContext;
        public GetEventCommandHandler(IMapper mapper, IEventContext eventContext, ITicketContext ticketContext)
        {
            _mapper = mapper;
            _eventContext = eventContext;
            _ticketContext = ticketContext;
        }
        public async Task<IEnumerable<EventDto>> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {

            var mappingObject = await _eventContext.GetEvents();
            var result = mappingObject.Select(entity => _mapper.Map<Event, EventDto>(entity)).ToList();

            foreach (var eventDto in result)
            {
                var tickets = await _ticketContext.GetTickets(eventDto.EventId);
                eventDto.Tickets = tickets.Select(p => _mapper.Map<Ticket, TicketDto>(p)).ToList();
            }

            foreach (var entity in result)
            {
                entity.IsHaveFreePlaces = await _eventContext.HaveEvent(entity.EventId) == true;
            }

            return result;
        }
    }
}
