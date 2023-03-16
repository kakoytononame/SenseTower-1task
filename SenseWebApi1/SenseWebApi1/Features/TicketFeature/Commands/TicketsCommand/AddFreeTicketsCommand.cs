using MediatR;
using SenseWebApi1.domain.Dtos;

namespace SenseWebApi1.Features.MyFeature.Commands.TicketsCommand
{
    public class AddFreeTicketsCommand:IRequest<bool>
    {

        public Guid EventId { get; set; }

        public int countoftickets { get; set; }


    }
}
