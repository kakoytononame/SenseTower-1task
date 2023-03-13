using AutoMapper;
using MediatR;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Commands.ImagesCommands;
using SenseWebApi1.Stubs;

namespace SenseWebApi1.Features.MyFeature.MyFeatureController.Handlers.ImagesHandlers
{
    public class GetImagesCommandHandler : IRequestHandler<GetImagesCommand, List<ImageDto>>
    {
        private readonly IImageContext _imageContext;
        private IMapper _mapper;
        public GetImagesCommandHandler(IMapper mapper, IImageContext imageContext)
        {
            _mapper = mapper;
            _imageContext = imageContext;
        }

        public async Task<List<ImageDto>> Handle(GetImagesCommand request, CancellationToken cancellationToken)
        {
            var mappingobject = _imageContext.GetImages();
            List<ImageDto> result = new List<ImageDto>();
            foreach (var entity in mappingobject)
            {
                result.Add(_mapper.Map<Image, ImageDto>(entity));
            }

            return result;
        }
    }
}
