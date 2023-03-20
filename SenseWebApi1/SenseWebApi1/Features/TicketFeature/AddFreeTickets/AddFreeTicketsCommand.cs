using MediatR;

namespace SenseWebApi1.Features.TicketFeature.AddFreeTickets
{
    public class AddFreeTicketsCommand : IRequest<bool>
    {

        public Guid EventId { get; set; }

        // ReSharper disable once IdentifierTypo
        public int Countoftickets { get; set; }


    }
}
