using MediatR;

namespace SenseWebApi1.Features.MyFeature.Commands.EventsCommands
{
    public class EventDeleteCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }
}
