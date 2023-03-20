using AutoMapper;

namespace SenseWebApi1.Features.EventFeature
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
