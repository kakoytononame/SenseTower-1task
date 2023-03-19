using AutoMapper;
using SenseWebApi1.Features.TicketFeature;

namespace SenseWebApi1.Mapping
{
    public class TicketProfile:Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();
        }
    }
}
