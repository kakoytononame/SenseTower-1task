using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.ImagesCommands;

namespace SenseWebApi1.Mapping
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageCheckCommand, Image>();
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}
