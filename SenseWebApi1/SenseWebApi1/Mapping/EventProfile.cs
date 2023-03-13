using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Mapping
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
