using MediatR;
using SenseWebApi1.domain.Dtos;

namespace SenseWebApi1.Features.MyFeature.Commands.ImagesCommands
{
    public class GetImagesCommand : IRequest<List<ImageDto>>
    {
        public Guid ImageId { get; set; }
        public string? src { get; set; }
    }
}
