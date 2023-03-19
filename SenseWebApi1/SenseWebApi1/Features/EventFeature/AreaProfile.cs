using AutoMapper;

namespace SenseWebApi1.Features.EventFeature
{
    public class AreaProfile:Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();
            
        }
    }
}
