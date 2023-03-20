using MediatR;

namespace SenseWebApi1.Features.TicketFeature.GiveTicketForUser
{
    public class GiveTicketForUserCommand : IRequest<Guid>
    {
        public Guid TicketId { get; set; }

        public Guid OwnerId { get; set; }
        
        public int? Place { get; set; }
        
        
    }
}
