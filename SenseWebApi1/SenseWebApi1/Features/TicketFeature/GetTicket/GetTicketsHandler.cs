using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.GetTicket
{
    public class GetTicketsHandler : IRequestHandler<GetTicketsCommand, List<Ticket>>
    {
        private readonly ITicketContext _ticketContext;
        public GetTicketsHandler(ITicketContext ticketContext)
        {
                _ticketContext = ticketContext;
        }
        public async Task<List<Ticket>> Handle(GetTicketsCommand request, CancellationToken cancellationToken)
        {
            var result =_ticketContext.GetTickets(request.EventId);
            return await result;
        }
    }
}
