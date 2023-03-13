using MediatR;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Commands
{
    public class EventCreateCommand:IRequest<Guid>
    {
        public Guid EventId { get; set; }
        public DateTime Beginning { get; set; }
        
        public DateTime End { get; set; }
        
        public string ?EventName { get; set; }
        
        public string ?Description { get; set; }
        
        public Guid ImageId { get; set; }

        public Guid AreaId { get; set; }

    }
}
