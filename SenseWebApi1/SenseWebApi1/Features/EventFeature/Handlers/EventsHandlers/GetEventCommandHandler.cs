using AutoMapper;
using MediatR;
using SenseWebApi1.Context;
using SenseWebApi1.domain.Dtos;
using SenseWebApi1.domain.Entities;
using SenseWebApi1.Features.MyFeature.Commands.EventsCommands;
using System.Collections.Generic;

namespace SenseWebApi1.Features.MyFeature.Handlers.EventsHandlers
{
    public class GetEventCommandHandler : IRequestHandler<GetEventCommand, IEnumerable<EventDto>>
    {

        private readonly IEventContext _eventContext;
        private IMapper _mapper;
        public GetEventCommandHandler(IMapper mapper, IEventContext eventContext)
        {
            _mapper = mapper;
            _eventContext = eventContext;
        }
        public async Task<IEnumerable<EventDto>> Handle(GetEventCommand request, CancellationToken cancellationToken)
        {

            var mappingobject = _eventContext.GetEvents();
            List<EventDto> result = new List<EventDto>();
            foreach (var entity in mappingobject)
            {
                result.Add(_mapper.Map<Event, EventDto>(entity));
            }

            return result;
        }
    }
}
