using MediatR;

namespace SenseWebApi1.Features.TicketFeature.CheckTicketForUser
{
    public class CheckTicketForUserCommand : IRequest<bool>
    {
        public Guid OwnerId { get; set; }

        public Guid EventId { get; set; }
    }
}
