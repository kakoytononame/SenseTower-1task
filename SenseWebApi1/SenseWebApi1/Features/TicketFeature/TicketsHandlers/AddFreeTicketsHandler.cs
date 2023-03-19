using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.TicketsHandlers
{
    public class AddFreeTicketsHandler : IRequestHandler<AddFreeTicketsCommand, bool>
    {
        private readonly ITicketContext _ticketContext;
        public AddFreeTicketsHandler(ITicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public async Task<bool> Handle(AddFreeTicketsCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                await _ticketContext.AddFreeTickets(request.EventId, request.Countoftickets);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
