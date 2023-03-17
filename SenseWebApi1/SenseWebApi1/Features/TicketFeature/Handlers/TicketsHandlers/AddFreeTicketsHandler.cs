using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.TicketsCommand;


namespace SenseWebApi1.Features.TicketFeature.Handlers.TicketsHandlers
{
    public class AddFreeTicketsHandler : IRequestHandler<AddFreeTicketsCommand, bool>
    {
        ITicketContext _ticketcontext;
        public AddFreeTicketsHandler(ITicketContext ticketContext)
        {
            _ticketcontext = ticketContext;
        }
        public async Task<bool> Handle(AddFreeTicketsCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                _ticketcontext.AddFreeTickets(request.EventId, request.countoftickets);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
