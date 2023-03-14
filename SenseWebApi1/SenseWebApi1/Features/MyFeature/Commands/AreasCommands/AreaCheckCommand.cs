using MediatR;

namespace SenseWebApi1.Features.MyFeature.Commands.AreasCommands
{
    public class AreaCheckCommand : IRequest<bool>
    {
        public Guid AreaId { get; set; }
    }
}
