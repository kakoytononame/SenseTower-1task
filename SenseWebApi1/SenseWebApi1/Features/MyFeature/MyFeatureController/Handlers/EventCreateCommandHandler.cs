using MediatR;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers
{
    public class EventCreateCommandHandler:IRequestHandler<EventCreateCommand,Guid>
    {

        public Task<Guid> Handle(EventCreateCommand command,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
