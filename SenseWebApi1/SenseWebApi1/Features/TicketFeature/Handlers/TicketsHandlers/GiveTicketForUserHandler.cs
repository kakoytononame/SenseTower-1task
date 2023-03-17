using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.Handlers.TicketsHandlers
{
    public class GiveTicketForUserHandler:IRequestHandler<GiveTicketForUserCommand,Guid>
    {
        ITicketContext _ticketContext;
        public GiveTicketForUserHandler(ITicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<Guid> Handle(GiveTicketForUserCommand request, CancellationToken cancellationToken)
        {
            
             _ticketContext.GiveTicketForUser(request.OwnerId, request.TicketId);
             return request.TicketId;
           
        }
    }
}
