using MediatR;
using SenseWebApi1.Features.TicketFeature;

namespace SenseWebApi1.Features.TicketFeature.TicketsCommand
{
    public class AddFreeTicketsCommand : IRequest<bool>
    {

        public Guid EventId { get; set; }

        public int Countoftickets { get; set; }


    }
}
