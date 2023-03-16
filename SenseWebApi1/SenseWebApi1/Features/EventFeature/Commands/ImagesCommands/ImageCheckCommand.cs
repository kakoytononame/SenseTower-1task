using MediatR;

namespace SenseWebApi1.Features.MyFeature.Commands.ImagesCommands
{
    public class ImageCheckCommand : IRequest<bool>
    {
        public Guid ImageId { get; set; }

    }
}
