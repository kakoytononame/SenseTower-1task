using AutoMapper;
using SenseWebApi1.Features.EventFeature;

namespace SenseWebApi1.Mapping
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {
            
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}
