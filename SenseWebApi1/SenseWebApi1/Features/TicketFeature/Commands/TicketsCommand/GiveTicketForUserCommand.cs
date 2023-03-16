using MediatR;

namespace SenseWebApi1.Features.TicketFeature.Commands.TicketsCommand
{
    public class GiveTicketForUserCommand:IRequest<Guid>
    {
        public Guid TicketId { get; set; }

        public Guid OwnerId { get; set; }
    }
}
