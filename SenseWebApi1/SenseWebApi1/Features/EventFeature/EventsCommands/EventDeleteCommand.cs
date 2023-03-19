using MediatR;

namespace SenseWebApi1.Features.EventFeature.EventsCommands
{
    public class EventDeleteCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }
}
