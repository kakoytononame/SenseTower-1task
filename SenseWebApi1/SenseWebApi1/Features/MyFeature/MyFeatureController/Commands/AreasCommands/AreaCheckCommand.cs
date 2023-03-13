using MediatR;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.AreasCommands
{
    public class AreaCheckCommand : IRequest<bool>
    {
        public Guid AreaId { get; set; }
    }
}
