using MediatR;

namespace SenseWebApi1.Features.EventFeature.DeleteEvent
{
    public class EventDeleteCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }
}
