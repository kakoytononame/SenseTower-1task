using MediatR;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Commands
{
    public class EventDeleteCommand:IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }
}
