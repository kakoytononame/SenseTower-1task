using AutoMapper;
using SenseWebApi1.Features.EventFeature;
using SenseWebApi1.Features.EventFeature.EventsCommands;

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
