using MediatR;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers
{
    public class EventDeleteCommandHandler : IRequestHandler<EventDeleteCommand, Guid>
    {

        public Task<Guid> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
