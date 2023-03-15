using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.Commands.TicketsCommand;

namespace SenseWebApi1.Features.MyFeature.Handlers.TicketsHandlers
{
    public class AddFreeTicketsHandler : IRequestHandler<AddFreeTicketsCommand,bool>
    {
        ITicketContext _ticketcontext;
        public AddFreeTicketsHandler(ITicketContext ticketContext)
        {
            _ticketcontext = ticketContext;
        }
        public async Task<bool> Handle(AddFreeTicketsCommand request, CancellationToken cancellationToken)
        {
            var ticket=new TicketDto()
            {
                OwnerId = null,
                AreaId=request.AreaId,
            };
            try
            {
                _ticketcontext.AddFreeTickets(ticket,request.countoftickets);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
