using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.ImagesCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.ImagesHandlers
{
    public class ImageCheckCommandHandler : IRequestHandler<ImageCheckCommand, bool>
    {
        private readonly IImageContext _imageContext;
        private readonly IMapper _mapper;
        public ImageCheckCommandHandler(IImageContext imageContext, IMapper mapper)
        {
            _imageContext = imageContext;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ImageCheckCommand request, CancellationToken cancellationToken)
        {
            var imagecheck = _mapper.Map<ImageCheckCommand, Image>(request);
            var result = _imageContext.IsHave(imagecheck.ImageId);
            return result;
        }
    }
}
