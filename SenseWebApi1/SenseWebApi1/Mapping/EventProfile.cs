using AutoMapper;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;

namespace SenseWebApi1.Mapping
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<EventDto, EventCreateCommand>();
            CreateMap<EventDto, EventUpdateCommand>();
            CreateMap<EventUpdateCommand, Event>();
        }
    }
}
