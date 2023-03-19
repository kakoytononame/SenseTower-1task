using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.TicketsHandlers
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
