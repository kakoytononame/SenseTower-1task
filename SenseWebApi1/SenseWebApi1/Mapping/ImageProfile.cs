using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

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
