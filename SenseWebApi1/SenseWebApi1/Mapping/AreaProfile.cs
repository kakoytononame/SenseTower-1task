using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.AreasCommands;


namespace SenseWebApi1.Mapping
{
    public class AreaProfile:Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();
            CreateMap<AreaCheckCommand, Area>();
        }
    }
}
