using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers
{
    public class EventUpdateCommandHandler : IRequestHandler<EventUpdateCommand, EventDto>
    {
        public Task<EventDto> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
