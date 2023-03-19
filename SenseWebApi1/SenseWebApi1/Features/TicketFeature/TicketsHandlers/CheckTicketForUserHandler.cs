using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.Features.TicketFeature.TicketsCommand;

namespace SenseWebApi1.Features.TicketFeature.TicketsHandlers
{
    public class CheckTicketForUserHandler : IRequestHandler<CheckTicketForUserCommand, bool>
    {
        private readonly ITicketContext _ticketContext;
        public CheckTicketForUserHandler(ITicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<bool> Handle(CheckTicketForUserCommand request, CancellationToken cancellationToken)
        {
            var result = _ticketContext.CheckTicketForUser(request.OwnerId,request.EventId);
            return await result;
        }
    }
}
