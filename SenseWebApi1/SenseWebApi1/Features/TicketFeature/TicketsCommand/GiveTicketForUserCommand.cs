using MediatR;

namespace SenseWebApi1.Features.TicketFeature.TicketsCommand
{
    public class GiveTicketForUserCommand : IRequest<Guid>
    {
        public Guid TicketId { get; set; }

        public Guid OwnerId { get; set; }
    }
}
