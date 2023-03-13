using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand, EventDto>
    {
        public Task<EventDto> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
