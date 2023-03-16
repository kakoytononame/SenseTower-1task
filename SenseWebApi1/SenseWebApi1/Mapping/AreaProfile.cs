using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;


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
