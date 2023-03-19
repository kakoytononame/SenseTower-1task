using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.TicketsHandlers
{
    public class GiveTicketForUserHandler:IRequestHandler<GiveTicketForUserCommand,Guid>
    {
        private readonly ITicketContext _ticketContext;
        public GiveTicketForUserHandler(ITicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<Guid> Handle(GiveTicketForUserCommand request, CancellationToken cancellationToken)
        {
            
             await _ticketContext.GiveTicketForUser(request.OwnerId, request.TicketId);
             return request.TicketId;
           
        }
    }
}
