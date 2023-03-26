using MediatR;
using SenseWebApi1.Context;

namespace SenseWebApi1.Features.TicketFeature.AddFreeTickets
{
    public class AddFreeTicketsHandler : IRequestHandler<AddTicketsCommand, bool>
    {
        private readonly ITicketContext _ticketContext;
        public AddFreeTicketsHandler(ITicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public async Task<bool> Handle(AddTicketsCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                await _ticketContext.AddTickets(request.EventId, request.Countoftickets);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
