using AutoMapper;
using SenseWebApi1.Features.EventFeature;

namespace SenseWebApi1.Mapping
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
