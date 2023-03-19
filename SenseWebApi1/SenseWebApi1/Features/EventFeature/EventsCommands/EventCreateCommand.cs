using MediatR;

namespace SenseWebApi1.Features.EventFeature.EventsCommands
{
    public class EventCreateCommand : IRequest<Guid>
    {

        public DateTime Beginning { get; set; }

        public DateTime End { get; set; }

        public string? EventName { get; set; }

        public string? Description { get; set; }

        public Guid ImageId { get; set; }

        public Guid AreaId { get; set; }

    }
}
