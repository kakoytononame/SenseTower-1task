using MediatR;

namespace SenseWebApi1.Features.TicketFeature.AddFreeTickets
{
    public class AddFreeTicketsCommand : IRequest<bool>
    {

        public Guid EventId { get; set; }

        public int Countoftickets { get; set; }


    }
}
