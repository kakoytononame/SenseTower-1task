using MediatR;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.EventsCommands
{
    public class EventDeleteCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }
}
