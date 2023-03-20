using Amazon.Runtime.Internal;
using MediatR;

namespace SenseWebApi1.Features.EventFeature.CheckPlaceForEvent
{
    public class CheckPlaceForEventCommand: IRequest<bool>
    {
        public Guid eventId { set; get; }

        public int place {  set; get; }

    }
}
